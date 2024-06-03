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
        private readonly ICourseRepository _courseRepository;
        private readonly IDepartmentCourseRepository _depCourseRepo;
        private readonly IStudentDepDetailsRepository _studentDepDetailsRepo;
        private readonly IStudentCourseDetailsRepostiory _studentCourseDetailsRepo;
        private readonly ICourseClassRepository _courseClassRepository; 
        private readonly IUniversityRepository _universityRepository;
        private readonly ICourseDetailsRepository _courseDetailsRepository;
        private readonly ILecturerAccountRepository _lecturerAccountRepository;
        public StudentCourseSelectionController(
            IStudentCourseSelectionRepository studentCourseSelectionRepository, IStudentCourseSelectRepository studentCourseSelectRepository,
            IDepartmentRepository departmentCourseSelectRepository, ICourseRepository courseRepository, IDepartmentCourseRepository departmentCourseRepository,
            IStudentDepDetailsRepository studentDepDetailsRepo,  IStudentCourseDetailsRepostiory studentCourseDetailsRepository,
            ICourseClassRepository courseClassRepository, IUniversityRepository universityRepository, ICourseDetailsRepository courseDetailsRepository,
            ILecturerAccountRepository lecturerAccountRepository
        )
        {
            _courseSelectionDetailsRepo = studentCourseSelectionRepository;
            _selectedCoursesRepo = studentCourseSelectRepository;
            _departmentRepo = departmentCourseSelectRepository;
            _courseRepository = courseRepository;
            _depCourseRepo = departmentCourseRepository;
            _studentDepDetailsRepo = studentDepDetailsRepo;
            _studentCourseDetailsRepo = studentCourseDetailsRepository;
            _courseClassRepository = courseClassRepository;
            _universityRepository = universityRepository;
            _courseDetailsRepository = courseDetailsRepository;
            _lecturerAccountRepository = lecturerAccountRepository;
        }

        [HttpGet("University/Faculty/Department/Semester/Student/Courses/Selected")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetCourseSelectionApi([FromQuery] String DepartmentName){
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);
            
            return await GetCourseSelection(DepartmentName, TC);
        }

        [HttpGet("University/Faculty/Department/Semester/Lecturer/Courses/Selected")]
        [Authorize(Roles = "Advisor")]
        public async Task<IActionResult> GetStudentCourseSelectionApi([FromQuery] String DepartmentName, [FromQuery] String TC){
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            return await GetCourseSelection(DepartmentName, TC);
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

            ICollection<SelectedCourseDto> selectedCourseDto = [];
            foreach(var cClass in courseClasses){
                var depCourse = await _depCourseRepo.GetDeparmentCourseByCourseCodeAsync(cClass.CourseCode);
                var courseDetails = await _courseDetailsRepository.GetCourseDetailsAsync(depCourse.CourseDetailsId);
                var selectedCourse = new SelectedCourseDto{
                    CourseCode = cClass.CourseCode,
                    ATKS = cClass.AKTS,
                    Kredi = cClass.Kredi,
                    LecturerTC = cClass.LecturerTC,
                    CourseType = courseDetails.CourseType,
                    TaughtSemester = depCourse.TaughtSemester
                };
                selectedCourseDto.Add(selectedCourse);
            }
            
            return Ok(courseSelectionDetails.ToCourseSelectionDetailsDto(selectedCourseDto));
        }
        [HttpPost("University/Faculty/Department/Semester/Student/Courses/Selected")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> AddCourseSelection([FromBody] CourseSelectionPostDto courseSelectionPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentDepDetailsRepo = await _studentDepDetailsRepo.GetStudentDepDetailAsync(courseSelectionPostDto.TC, courseSelectionPostDto.DepartmentName);
            if(studentDepDetailsRepo == null){
                return BadRequest("Student not registered on this course.");
            }

            ICollection<CourseClass> courseClasses = [];
            ICollection<DepartmentCourse> depCourses = [];

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            if(uni == null){
                return StatusCode(500, "Failed to get university data");
            }

            foreach(var selectedCourse in courseSelectionPostDto.SelectedCourses){
                var depCourse = await _depCourseRepo.GetDeparmentCourseByCourseCodeAsync(selectedCourse.CourseCode);
                if(depCourse == null){
                    return BadRequest("Wrong Course Code");
                }
                var courseClass = await _courseClassRepository.GetCourseClassAsync(selectedCourse.CourseCode, uni.CurrentSchoolYear);
                if(courseClass == null){
                    return BadRequest("Course not opened.");
                }
                depCourses.Add(depCourse);
                courseClasses.Add(courseClass);
            }
            
            
            
            return Ok();
        }
        [HttpGet("University/Faculty/Department/Semester/Student/Courses/Available")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetAvailableCourseSelection([FromQuery] String DepName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validDepartment = await _departmentRepo.GetDepartmentAsync(DepName);

            if(validDepartment == null){
                return NotFound("Department not found!");
            }

            TimeSpan start = TimeSpan.FromTicks(validDepartment.CourseSelectionStartDate.Ticks);
            TimeSpan current = TimeSpan.FromTicks(DateTime.Now.Ticks);
            TimeSpan end = TimeSpan.FromTicks(validDepartment.CourseSelectionEndDate.Ticks);

            if(current < start || current > end){
                return BadRequest("Course Selection is closed.");
            }

            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            var depsDetails = await _studentDepDetailsRepo.GetStudentDepDetailAsync(TC, DepName);

            if(depsDetails == null){
                return NotFound("You're not registered on this course");
            }

            CoursesSelectionGETDto list = await GetAvailableCourseSelectionList(depsDetails);

            return Ok(list);
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
    }
}