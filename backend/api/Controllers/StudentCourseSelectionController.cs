using api.Mappers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.DTO.CourseSelection;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class StudentCourseSelectionController : ControllerBase
    {
        private readonly IStudentCourseSelectionRepository _courseSelectionDetailsRepo;
        private readonly IStudentCourseSelectRepository _selectedCoursesRepo;
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IDepartmentCourseRepository _depCourseRepo;
        private readonly IStudentDepDetailsRepository _studentDepDetailsRepo;
        private readonly IStudentCourseDetailsRepostiory _studentCourseDetailsRepo;
        private readonly ICourseClassRepository _courseClassRepository; 
        private readonly IUniversityRepository _universityRepository;
        private readonly ICourseDetailsRepository _courseDetailsRepository;
        private readonly ILecturerAccountRepository _lecturerAccountRepository;
        private readonly ISemesterDetailsRepository  _semesterDetails;
        private readonly IStudentAccountRepository _studentAccountRepository;
        private readonly IDocumentRequestRepository _documentRequestRepository;
        public StudentCourseSelectionController(
            IStudentCourseSelectionRepository studentCourseSelectionRepository, IStudentCourseSelectRepository studentCourseSelectRepository,
            IDepartmentRepository departmentCourseSelectRepository, IDepartmentCourseRepository departmentCourseRepository,
            IStudentDepDetailsRepository studentDepDetailsRepo,  IStudentCourseDetailsRepostiory studentCourseDetailsRepository,
            ICourseClassRepository courseClassRepository, IUniversityRepository universityRepository, ICourseDetailsRepository courseDetailsRepository,
            ILecturerAccountRepository lecturerAccountRepository, ISemesterDetailsRepository semesterDetailsRepository, IStudentAccountRepository studentAccountRepository,
            IDocumentRequestRepository documentRequestRepository
        )
        {
            _courseSelectionDetailsRepo = studentCourseSelectionRepository;
            _selectedCoursesRepo = studentCourseSelectRepository;
            _departmentRepo = departmentCourseSelectRepository;
            _depCourseRepo = departmentCourseRepository;
            _studentDepDetailsRepo = studentDepDetailsRepo;
            _studentCourseDetailsRepo = studentCourseDetailsRepository;
            _courseClassRepository = courseClassRepository;
            _universityRepository = universityRepository;
            _courseDetailsRepository = courseDetailsRepository;
            _lecturerAccountRepository = lecturerAccountRepository;
            _semesterDetails = semesterDetailsRepository;
            _studentAccountRepository = studentAccountRepository;
            _documentRequestRepository = documentRequestRepository;
        }

        [HttpGet("University/Faculty/Department/Semester/Student/Courses/Selected")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetCourseSelectionApi([FromQuery] String DepartmentName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            if(!await CourseSelectionTime(DepartmentName)){
                return BadRequest();
            }
            
            return await GetCourseSelection(DepartmentName, TC);
        }
        [HttpGet("University/Faculty/Department/Semester/Advisor/Courses/Selected")]
        [Authorize(Roles = "Advisor")]
        public async Task<IActionResult> GetStudentCourseSelectionApi([FromQuery] String DepartmentName, [FromQuery] int SSN){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentAcc = await _studentAccountRepository.GetStudentAccountBySSNAsync(SSN);
            if(studentAcc == null){
                return NotFound("Student not found");
            }

            var dep = await _departmentRepo.GetDepartmentAsync(DepartmentName);
            if(dep == null){
                return NotFound("Department not found");
            }
            
            return await GetCourseSelection(DepartmentName, studentAcc.TC);
        }
        private async Task<IActionResult> GetCourseSelection(String DepartmentName, String TC){
            var depsDetails = await _studentDepDetailsRepo.GetStudentDepDetailAsync(TC, DepartmentName);

            if(depsDetails == null){
                return BadRequest("Student not registered on this department");
            }

            var courseSelectionDetails = await _courseSelectionDetailsRepo.GetCourseSelectionDetailsAsync(DepartmentName, TC);
            if(courseSelectionDetails == null){
                return BadRequest();
            }

            var selectedCourses = await _selectedCoursesRepo.GetSelectedCoursesAsync(DepartmentName, TC);
            if(selectedCourses == null){
                return BadRequest();
            }

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            if(uni == null){
                return BadRequest();
            }

            ICollection<CourseClass> courseClasses = [];
            foreach(var course in selectedCourses){
                var cClass = await _courseClassRepository.GetCourseClassAsync(course.CourseCode, uni.CurrentSchoolYear);
                if(cClass == null){
                    return BadRequest();
                }
                courseClasses.Add(cClass);
            }

            ICollection<SelectedCourseGETDto> selectedCourseDto = [];
            foreach(var cClass in courseClasses){
                var depCourse = await _depCourseRepo.GetDeparmentCourseByCourseCodeAsync(cClass.CourseCode);
                var courseDetails = await _courseDetailsRepository.GetCourseDetailsAsync(depCourse.CourseDetailsId);
                var lecturer = await _lecturerAccountRepository.GetLecturerAccountByTCAsync(cClass.LecturerTC);
                var selectedCourse = new SelectedCourseGETDto{
                    CourseCode = cClass.CourseCode,
                    CourseName = depCourse.CourseName,
                    AKTS = cClass.AKTS,
                    Kredi = cClass.Kredi,
                    LecturerName = lecturer.FirstName + " " + lecturer.LastName,
                    CourseType = courseDetails.CourseType,
                };
                selectedCourseDto.Add(selectedCourse);
            }
            
            return Ok(courseSelectionDetails.ToCourseSelectionDetailsDto(selectedCourseDto));
        }
        [HttpPost("University/Faculty/Department/Semester/Student/Courses/Select")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> AddCourseSelection([FromBody] CourseSelectionPostDto courseSelectionPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!await CourseSelectionTime(courseSelectionPostDto.DepartmentName)){
                return BadRequest();
            }

            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            var studentDepDetails = await _studentDepDetailsRepo.GetStudentDepDetailAsync(TC, courseSelectionPostDto.DepartmentName);
            if(studentDepDetails == null){
                return BadRequest("Student not registered on this course.");
            }
            
            var semesterDetail = await _semesterDetails.GetSemesterDetailsAsync(courseSelectionPostDto.DepartmentName, studentDepDetails.CurrentSemester);

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            if(uni == null){
                return StatusCode(500, "Failed to get university data");
            }

            //ICollection<CourseClass> courseClasses = [];
            //ICollection<DepartmentCourse> depCourses = [];

            int selectedAKTS = 0;
            foreach(var selectedCourse in courseSelectionPostDto.SelectedCoursesCodes){
                var depCourse = await _depCourseRepo.GetDeparmentCourseByCourseCodeAsync(selectedCourse);
                if(depCourse == null){
                    return BadRequest("Wrong Course Code");
                }
                var courseClass = await _courseClassRepository.GetCourseClassAsync(selectedCourse, uni.CurrentSchoolYear);
                if(courseClass == null){
                    return BadRequest("Course not opened.");
                }
                //depCourses.Add(depCourse);
                selectedAKTS += courseClass.AKTS;
            }

            if(courseSelectionPostDto.SelectedCoursesCodes.Count != courseSelectionPostDto.SelectedCoursesCodes.Distinct().Count()){
                // Duplicates exist
                return BadRequest("Cannot select a course twice.");
            }   

            if(AKTSExceeded(selectedAKTS, studentDepDetails.CurrentSemester)){
                return BadRequest("Max AKTS exceeded.");
            }

            CoursesSelectionGETDto list = await GetAvailableCourseSelectionList(studentDepDetails);

            List<string> failedCoursesList = [];
            if(list.FailedCourses != null){
                failedCoursesList = list.FailedCourses.ToCourseCodeList();
            }

            List<string> passedCoursesList = [];
            if(list.PassedCourses != null){
                passedCoursesList = list.PassedCourses.ToCourseCodeList();
            }

            List<string> mandatoryCoursesList = [];
            List<string> OptionalCoursesList = [];
            if(list.CurrentSemesterCourses != null){
                mandatoryCoursesList = list.CurrentSemesterCourses.GetSpecificCourse("Mandatory");
                OptionalCoursesList = list.CurrentSemesterCourses.GetSpecificCourse("Optional");
            }

            List<string> PartiallyPassedCourses = [];
            if(list.PartiallyPassedCourses != null){
                PartiallyPassedCourses = list.PartiallyPassedCourses.ToCourseCodeList();
            }

            List<string> OverHeadCoursesList = [];
            if(list.OverHeadCourses != null){
                OverHeadCoursesList = list.OverHeadCourses.ToCourseCodeList();
            }

            // Check to see if the selected courses are in the available pool.
            foreach(var selectedCourse in courseSelectionPostDto.SelectedCoursesCodes){
                if(failedCoursesList.Contains(selectedCourse) || passedCoursesList.Contains(selectedCourse) || 
                    mandatoryCoursesList.Contains(selectedCourse) || OptionalCoursesList.Contains(selectedCourse)
                    || PartiallyPassedCourses.Contains(selectedCourse) || OverHeadCoursesList.Contains(selectedCourse))
                    continue;
                return BadRequest("One of the selected courses is not available to you. Please check");
            }

            // All failed courses have priority.
            foreach(var failedCourse in failedCoursesList){
                if(courseSelectionPostDto.SelectedCoursesCodes.Contains(failedCourse)){
                    continue;
                }
                return BadRequest("All failed courses must be taken.");
            }

            if (studentDepDetails.Gno < 1.8)
            {
                foreach (var selectedCourse in courseSelectionPostDto.SelectedCoursesCodes){
                    if (!PartiallyPassedCourses.Contains(selectedCourse) && !failedCoursesList.Contains(selectedCourse))
                    {
                        return BadRequest("Only partially passed and failed courses can be taken.");
                    }
                }
            }

            if (studentDepDetails.Gno < 2.0)
            {
                foreach (var partiallyPassedCourse in PartiallyPassedCourses)
                {
                    if (!courseSelectionPostDto.SelectedCoursesCodes.Contains(partiallyPassedCourse))
                    {
                        return BadRequest("All partially passed courses must be taken.");
                    }
                }
            }

            var numOfPartiallyPassedRetakenCourses = 0;
            foreach(var partiallyPassedCourse in PartiallyPassedCourses){
                if(courseSelectionPostDto.SelectedCoursesCodes.Contains(partiallyPassedCourse)){
                    numOfPartiallyPassedRetakenCourses++;
                }
            }

            var numOfPassedRetakenCourses = 0;
            foreach(var passedCourses in passedCoursesList){
                if(courseSelectionPostDto.SelectedCoursesCodes.Contains(passedCourses)){
                    if(studentDepDetails.Gno <= 2.0)
                        return BadRequest("You can only retake passed courses if GNO > 2.0");
                    numOfPassedRetakenCourses++;
                }
            }

            int numOfOVerHeadCourses = 0;
            if(OverHeadCoursesList != null){
                foreach(var OverHeadCourse in OverHeadCoursesList){
                    if(courseSelectionPostDto.SelectedCoursesCodes.Contains(OverHeadCourse))
                        numOfOVerHeadCourses++;
                }
            }
            if ( numOfOVerHeadCourses != 0 && (studentDepDetails.Gno < 3.0 || list.FailedCourses == null ) ){
                return BadRequest("Overhead courses can only be taken if GNO >= 3.0 and no failed courses.");
            }

            int numOfSelectiveCourses = 0;
            foreach(var optionalCourse in OptionalCoursesList){
                if(courseSelectionPostDto.SelectedCoursesCodes.Contains(optionalCourse))
                    numOfSelectiveCourses++;
            }
            if(numOfSelectiveCourses > semesterDetail.NumberOfSelectiveCourses){
                return BadRequest("");   
            }

            foreach(var mandatoryCourse in mandatoryCoursesList){
                if(!courseSelectionPostDto.SelectedCoursesCodes.Contains(mandatoryCourse)){
                    if(numOfSelectiveCourses != 0 || numOfOVerHeadCourses != 0 || numOfPassedRetakenCourses != 0 || numOfPartiallyPassedRetakenCourses != 0){
                        return BadRequest("Mandatory courses have priority over other courses except failed ones.");
                    }
                    int courseAKTS = list.CurrentSemesterCourses.GetSpecificCourseAKTS(mandatoryCourse);
                    if(!AKTSExceeded(selectedAKTS+courseAKTS, studentDepDetails.CurrentSemester)){
                        return BadRequest("Available Mandatory Courses must be taken");
                    }
                }
            }

            var record = new StudentCourseSelection{
                DepartmentName = courseSelectionPostDto.DepartmentName,
                TC = TC,
                SentDate = DateTime.Now,
                State = "On Review"
            };

            var createRecord = await _courseSelectionDetailsRepo.AddCourseSelectionDetailsAsync(record);
            if(createRecord == null){
                return StatusCode(500, "Failed to store the Course Selection data.");
            }

            foreach(var selectedCourse in courseSelectionPostDto.SelectedCoursesCodes){
                var addCourse = new StudentCourseSelect{
                    DepartmentName = courseSelectionPostDto.DepartmentName,
                    TC = TC,
                    CourseCode = selectedCourse,
                };
                var createCourseRecord = await _selectedCoursesRepo.AddSelectedCourseAsync(addCourse);
                if(createCourseRecord == null){
                    return StatusCode(500, "Failed to store the Course Selection data.");
                }
            }

            return Ok();
        }
        private bool AKTSExceeded(int selectedAKTS, int CurrentSemester){
            if((CurrentSemester > 6 && selectedAKTS > 48) || (CurrentSemester < 7 && selectedAKTS > 45))
                return true;
            return false;
        }
        [HttpGet("University/Faculty/Department/Semester/Student/Courses/Available")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetAvailableCourseSelection([FromQuery] String DepName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
 
            if(!await CourseSelectionTime(DepName)){
                return BadRequest();
            }
            
            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            var depsDetails = await _studentDepDetailsRepo.GetStudentDepDetailAsync(TC, DepName);

            if(depsDetails == null){
                return NotFound("You're not registered on this course");
            }

            CoursesSelectionGETDto list = await GetAvailableCourseSelectionList(depsDetails);

            return Ok(list);
        }
        private async Task<bool> CourseSelectionTime(String DepName){
            var validDepartment = await _departmentRepo.GetDepartmentAsync(DepName);

            if(validDepartment == null){
                return false;
            }

            TimeSpan start = TimeSpan.FromTicks(validDepartment.CourseSelectionStartDate.Ticks);
            TimeSpan current = TimeSpan.FromTicks(DateTime.Now.Ticks);
            TimeSpan end = TimeSpan.FromTicks(validDepartment.CourseSelectionEndDate.Ticks);

            if(current < start || current > end){
                return false;
            }

            return true;
        }
        private async Task<CoursesSelectionGETDto> GetAvailableCourseSelectionList(StudentDepDetails depDetails){
            CoursesSelectionGETDto list = new()
            {
                FailedCourses = await GetCoursesOfStudent("Failed", depDetails.DepartmentName, depDetails.TC, depDetails.CurrentSemester % 2),
                PartiallyPassedCourses = await GetCoursesOfStudent("Partially Passed", depDetails.DepartmentName, depDetails.TC, depDetails.CurrentSemester % 2)
            };
             
            if (depDetails.Gno != null && depDetails.Gno < 1.8 && depDetails.CurrentSemester > 4){
                return list;
            }

            if(depDetails.Gno != null && depDetails.Gno > 2){
                list.PassedCourses = await GetCoursesOfStudent("Passed", depDetails.DepartmentName, depDetails.TC, depDetails.CurrentSemester % 2);
            }

            list.CurrentSemesterCourses = await GetSemesterSelectionCourses(0, depDetails.DepartmentName, depDetails.StudentType, depDetails.CurrentSemester);

            if(depDetails.Gno > 3.0 && list.FailedCourses == null){
                list.OverHeadCourses =  await GetSemesterSelectionCourses(1, depDetails.DepartmentName, depDetails.StudentType, depDetails.CurrentSemester);
            }
            
            return list;
        }
        private async Task<ICollection<SelectedCourseGETDto>?> GetSemesterSelectionCourses(int type, String DepName, String StudentType, int Semester){
            var dep = await _departmentRepo.GetDepartmentAsync(DepName);
            if(dep == null){
                return null;
            }

            ICollection<DepartmentCourse>? courses = null;
            if(type == 0)
                courses = await _depCourseRepo.GetDepartmentSemesterCoursesAsync(DepName, StudentType, Semester);
            else
                courses = await _depCourseRepo.GetOverHeadDepCourses(DepName, StudentType, Semester);
            
            if(courses == null){
                return null;
            }
            
            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            if(uni == null){
                return null;
            }

            ICollection<SelectedCourseGETDto> courseSelectionList = [];
            foreach(var course in courses){
                var cc = await _courseClassRepository.GetCourseClassAsync(course.CourseCode, uni.CurrentSchoolYear);
                var lec = await _lecturerAccountRepository.GetLecturerAccountByTCAsync(cc.LecturerTC);
                var cd = await _courseDetailsRepository.GetCourseDetailsAsync(course.CourseDetailsId);
                var courseSelectionDto = new SelectedCourseGETDto{
                    CourseName = course.CourseName,
                    CourseCode = course.CourseCode,
                    CourseType = cd.CourseType,
                    AKTS = cc.AKTS,
                    Kredi = cc.Kredi,
                    LecturerName = lec.FirstName + lec.LastName
                };
                courseSelectionList.Add(courseSelectionDto);
            }

            return courseSelectionList;
        }
        private async Task<ICollection<SelectedCourseGETDto>?> GetCoursesOfStudent(String Type, String DepName, String TC, int semType){
            if(Type == null){
                return null;
            }
            ICollection<StudentCourseDetails>? coursesDetails = null;
            if(Type == "Failed"){
                coursesDetails = await _studentCourseDetailsRepo.GetFailedCoursesAsync(DepName, TC, semType);
            }else if(Type == "Passed")
                coursesDetails = await _studentCourseDetailsRepo.GetPassedCoursesAsync(DepName, TC, semType);
            else if(Type == "Partially Passed")
                coursesDetails = await _studentCourseDetailsRepo.GetPartiallyPassedCoursesAsync(DepName, TC, semType);
            else
                return null;

            if(coursesDetails == null)
                return null;

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            if(uni == null){
                return null;
            }

            ICollection<DepartmentCourse> courses = [];

            foreach(var courseDetail in coursesDetails){
                var course = await _depCourseRepo.GetDeparmentCourseByCourseCodeAsync(courseDetail.CourseCode);
                courses.Add(course);
            }

            if(courses == null){
                return null;
            }

            ICollection<SelectedCourseGETDto> courseSelectionList = [];
            foreach(var course in courses){
                var cc = await _courseClassRepository.GetCourseClassAsync(course.CourseCode, uni.CurrentSchoolYear);
                var lec = await _lecturerAccountRepository.GetLecturerAccountByTCAsync(cc.LecturerTC);
                var cd = await _courseDetailsRepository.GetCourseDetailsAsync(course.CourseDetailsId);
                var courseSelectionDto = new SelectedCourseGETDto{
                    CourseName = course.CourseName,
                    CourseCode = course.CourseCode,
                    CourseType = cd.CourseType,
                    AKTS = cc.AKTS,
                    Kredi = cc.Kredi,
                    LecturerName = lec.FirstName + lec.LastName
                };
                courseSelectionList.Add(courseSelectionDto);
            }

            return courseSelectionList;
        }
        [HttpPost("University/Faculty/Department/Course/Advisor/Student/Course/Accept/Selected")]
        [Authorize(Roles = "Advisor")]
        public async Task<IActionResult> AcceptStudentCourseSelection([FromQuery] String DepartmentName, [FromQuery] int SSN){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validStudent = await _studentAccountRepository.GetStudentAccountBySSNAsync(SSN);

            if(validStudent == null){
                return BadRequest("Student doesn't exist");
            }

            var validDep = await _departmentRepo.GetDepartmentAsync(DepartmentName);

            if(validDep == null){
                return BadRequest("Department doesn't exist");
            }

            var studentDepDetails = await _studentDepDetailsRepo.GetStudentDepDetailAsync(validStudent.TC, DepartmentName);
            if(studentDepDetails == null){
                return BadRequest("Student is not registered on this department.");
            }

            var selectedCourses = await _selectedCoursesRepo.GetSelectedCoursesAsync(DepartmentName, validStudent.TC);
            if(selectedCourses == null){
                return BadRequest();
            }

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            foreach(var course in selectedCourses){
                var validDepCourse = await _depCourseRepo.GetDeparmentCourseByCourseCodeAsync(course.CourseCode);
                if(validDepCourse == null){
                    return BadRequest("Department Course doesn't exist");
                }
                var validClass = await _courseClassRepository.GetCourseClassAsync(course.CourseCode, uni.CurrentSchoolYear);
                if(validClass == null){
                    return BadRequest("Course Class doesn't exist");
                }
                var prevStudentCourseDetails = await _studentCourseDetailsRepo.GetStudentCourseDetails(course.CourseCode, validStudent.TC, uni.CurrentSchoolYear-1);

                var studentCourseDetailsPost = new StudentCourseDetails{
                    CourseCode = course.CourseCode,
                    DepartmentName = validDepCourse.DepartmentName,
                    SchoolYear = uni.CurrentSchoolYear,
                    TC = validStudent.TC,
                    State = "Attending",
                    AttendanceFulfilled = null,
                    MidTerm = null,
                    Final = null,
                    ComplementRight = null,
                    Complement = null,
                    Grade = null
                };

                var studentCourseDetails = await _studentCourseDetailsRepo.CreateStudentCourseDetails(studentCourseDetailsPost);
                
                if(studentCourseDetails == null){
                    return BadRequest();
                }

                if(prevStudentCourseDetails != null){
                    studentCourseDetails.AttendanceFulfilled = prevStudentCourseDetails.AttendanceFulfilled;
                    prevStudentCourseDetails.State = "Re-Attended";
                }
            }

            var firstDeletion = await _selectedCoursesRepo.DeleteSelectedCoursesRangeAsync(selectedCourses);
            if(firstDeletion == null){
                return StatusCode(500, "Failed to delete selections after approvement");
            }

            var courseSelectionDetails = await _courseSelectionDetailsRepo.GetCourseSelectionDetailsAsync(DepartmentName, validStudent.TC);

            var secondDeletion = await _courseSelectionDetailsRepo.DeleteCourseSelectionDetailsAsync(courseSelectionDetails);
            if(secondDeletion == null){
                return StatusCode(500, "Failed to delete selection details after approvement");
            }
            
            return Ok();
        }
        [HttpPost("University/Faculty/Department/Course/Advisor/Student/Course/Reject/Selected")]
        [Authorize(Roles = "Advisor")]
        public async Task<IActionResult> RejectStudentCourseSelection([FromQuery] String DepartmentName, [FromQuery] int SSN){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validStudent = await _studentAccountRepository.GetStudentAccountBySSNAsync(SSN);

            if(validStudent == null){
                return BadRequest("Student doesn't exist");
            }

            var validDep = await _departmentRepo.GetDepartmentAsync(DepartmentName);

            if(validDep == null){
                return BadRequest("Department doesn't exist");
            }

            var studentDepDetails = await _studentDepDetailsRepo.GetStudentDepDetailAsync(validStudent.TC, DepartmentName);
            if(studentDepDetails == null){
                return BadRequest("Student is not registered on this department.");
            }

            var courseSelectionDetails = await _courseSelectionDetailsRepo.GetCourseSelectionDetailsAsync(DepartmentName, validStudent.TC);
            if(courseSelectionDetails == null){
                return BadRequest("No selection made from student!");
            }
            courseSelectionDetails.State = "Rejected";

            var result = await _courseSelectionDetailsRepo.UpdateCourseSelectionDetailsAsync(courseSelectionDetails);
            if(result == null){
                return StatusCode(500, "Failed to update student's course selection state");
            }

            return Ok();
        }  
        [HttpGet("University/Faculty/Department/Student/Transcript/")]
        [Authorize(Roles = "Student, Advisor")]
        public async Task<IActionResult> GetStudentTranscript([FromQuery] String DepName, [FromQuery] int SSN){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dep = await _departmentRepo.GetDepartmentAsync(DepName);
            if(dep == null){
                return NotFound();
            }

            var studentAcc = await _studentAccountRepository.GetStudentAccountBySSNAsync(SSN);
            if(studentAcc == null){
                return StatusCode(500, "Couldn't get account info.");
            }
            
            var studentDepDetails = await _studentDepDetailsRepo.GetStudentDepDetailAsync(studentAcc.TC, DepName);

            if(studentDepDetails == null){
                return BadRequest("Student not registered on this department.");
            }

            Transcript transcript = new()
            {
                DepartmentInfo = studentDepDetails.ToDepartmentInfo(dep.FacultyName),
                StudentInfo = studentAcc.ToStudentInfoDto(),
                Semesters = []
            };

            for (int i = 1; i <= dep.NumberOfSemesters; i++){
                var failedCourses = await _studentCourseDetailsRepo.GetSemesterFailedCoursesAsync(DepName, studentAcc.TC, i);
                var passedCourses = await _studentCourseDetailsRepo.GetSemesterPassedCoursesAsync(DepName, studentAcc.TC, i);
                var PartiallyPassedCourses = await _studentCourseDetailsRepo.GetSemesterPartiallyPassedCoursesAsync(DepName, studentAcc.TC, i);
                SemesterDto semesterDto = new()
                {
                    Semester = i,
                    Courses = []
                };
                
                if(failedCourses != null ){
                    var failedCoursesResult = await AddSemesterDetailsToTranscript(semesterDto, failedCourses);
                    if(!failedCoursesResult){
                        StatusCode(500, "Failed to add Failed Courses to Transcript.");
                    }
                }

                if(passedCourses != null ){
                    var passedCoursesResult = await AddSemesterDetailsToTranscript(semesterDto, passedCourses);
                    if(!passedCoursesResult){
                        StatusCode(500, "Failed to add Passed Courses to Transcript.");
                    }
                }

                if(PartiallyPassedCourses != null ){
                    var PartiallyPassedCoursesResult = await AddSemesterDetailsToTranscript(semesterDto, PartiallyPassedCourses);
                    if(!PartiallyPassedCoursesResult){
                        StatusCode(500, "Failed to add Partially Passed Courses to Transcript.");
                    }
                }
                transcript.Semesters.Add(semesterDto);
            }

            DocumentRequest transcriptRequestRecord = new DocumentRequest{
                TC = studentAcc.TC,
                DocumentType = "Transcript",
                DocumentLanguage = "Turkish",
                RequestDate = DateOnly.FromDateTime(DateTime.Now),
                State = "Approved"
            };

            var result = await _documentRequestRepository.AddDocumentRequestAsync(transcriptRequestRecord);
            if(result == null){
                return StatusCode(500, "Failed to save document request record.");
            }

            return Ok(transcript);
        }
        private async Task<bool> AddSemesterDetailsToTranscript(SemesterDto semesterDto,  ICollection<StudentCourseDetails> courses){
            foreach(var course in courses){
                String? Type;
                var courseDetail = await _depCourseRepo.GetDeparmentCourseByCourseCodeAsync(course.CourseCode);
                var courseClass = await _courseClassRepository.GetCourseClassAsync(course.CourseCode, course.SchoolYear);
                if(courseDetail == null){
                    return false;
                }
                if(courseDetail.TaughtSemester % 2 == 1){
                    Type = "Güz";
                }else{
                    Type = "Bahar";
                }
                var year = course.SchoolYear%2000;
                CourseDto courseDto = new(){
                    CourseCode = course.CourseCode,
                    CourseName = courseDetail.CourseName,
                    AKTS = courseClass.AKTS,
                    Kredi = courseClass.Kredi,
                    Grade = course.Grade,
                    SemesterYear = year + "/" + (int)(year + 1) + " " + Type
                };
                semesterDto.Courses.Add(courseDto);
            }
            return true;
        }
    }
}