using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using api.DTO.StudentCourseDetails;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class StudentCourseDetailsController : ControllerBase
    {
        private readonly IStudentCourseDetailsRepostiory _studentCourseDetailsRepository;
        private readonly ICourseClassRepository _courseClassRepository;
        private readonly IStudentAccountRepository _studentAccountRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUniversityRepository _universityRepository;
        private readonly IStudentDepDetailsRepository _studentDepDetailsRepository;
        private readonly ILecturerAccountRepository _lecturerAccountRepository;
        private readonly ILecturerDepDetailsRepository _lecturerDepDetailsRepository;
        private readonly IDepartmentCourseRepository _departmentCourseRepository;
        public StudentCourseDetailsController(IStudentCourseDetailsRepostiory studentCourseDetailsRepostiory, 
        ICourseClassRepository courseClassRepository, IStudentAccountRepository studentAccountRepository, 
        IDepartmentRepository departmentRepository, ICourseRepository courseRepository, 
        IUniversityRepository universityRepository, IStudentDepDetailsRepository studentDepDetailsRepository, 
        ILecturerDepDetailsRepository lecturerDepDetailsRepository, IDepartmentCourseRepository departmentCourseRepository,
        ILecturerAccountRepository lecturerAccountRepository){
            _studentCourseDetailsRepository = studentCourseDetailsRepostiory;
            _courseClassRepository = courseClassRepository;
            _studentAccountRepository = studentAccountRepository;
            _departmentRepository = departmentRepository;
            _courseRepository = courseRepository;
            _universityRepository = universityRepository;
            _studentDepDetailsRepository = studentDepDetailsRepository;
            _lecturerDepDetailsRepository = lecturerDepDetailsRepository;
            _departmentCourseRepository = departmentCourseRepository;
            _lecturerAccountRepository = lecturerAccountRepository;
        }
        [HttpGet("University/Faculty/Departments/Student/Courses/Details")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetStudentCoursesDetails([FromQuery] String DepName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CurrentTC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            var registered = await _studentDepDetailsRepository.GetStudentDepDetailAsync(CurrentTC, DepName);
            if(registered == null){
                return BadRequest("You're not registered on this department. If you are and it's not showing, contact support.");
            }
            
            var coursesDetails = await _studentCourseDetailsRepository.GetStudentsAllCourseDetails(DepName, CurrentTC);

            if(coursesDetails == null){
                return NotFound();
            }

            List<String> names = [];
            List<int> semesters = [];
            Dictionary<string, int> extraDetails = new Dictionary<string, int>();
            foreach(var courseDetail in coursesDetails){
                var departmentCourse = await _departmentCourseRepository.GetDeparmentCourseByCourseCodeAsync(courseDetail.CourseCode);
                names.Add(departmentCourse.CourseName);
                semesters.Add(departmentCourse.TaughtSemester);
            }


            
            return Ok(coursesDetails.ToStudentCourseDetailsDto(names, semesters));
        }
        [HttpGet("University/Faculty/Departments/Course/Student/Details")]
        [Authorize(Roles = "Lecturer, Student")]
        public async Task<IActionResult> GetStudentCourseDetails([FromQuery] String DepName, [FromQuery] String Course, [FromQuery] String TC){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CurrentTC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            if(CurrentTC != TC){
                var lecturer = await _lecturerDepDetailsRepository.GetLecturerDepDetailAsync(DepName, CurrentTC);
                if(lecturer == null){
                    return Unauthorized();
                }
            }

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(DepName, Course);

            if(depCourse == null){
                return NotFound();
            }

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            
            var courseClass = await _courseClassRepository.GetCourseClassAsync(depCourse.CourseCode, uni.CurrentSchoolYear);

            if(courseClass == null){
                return BadRequest(ModelState);
            }

            if(courseClass.LecturerTC != CurrentTC && CurrentTC != TC){
                return Unauthorized();
            }

            var registered = await _studentDepDetailsRepository.GetStudentDepDetailAsync(TC, DepName);
            if(registered == null){
                return BadRequest("Student is not registered on this department.");
            }
            
            var courseDetails = await _studentCourseDetailsRepository.GetStudentCourseDetails(depCourse.CourseCode, TC, uni.CurrentSchoolYear);

            if(courseDetails == null){
                return NotFound();
            }
            
            return Ok(courseDetails.ToStudentCourseDetailsDto(depCourse.CourseName, depCourse.TaughtSemester));
        }
        [HttpGet("University/Faculty/Departments/Course/Students/Details")]
        [Authorize(Roles = "Lecturer")]
        public async Task<IActionResult> GetCoursesStudentsDetails([FromQuery] String CourseCode){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CurrentTC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseByCourseCodeAsync(CourseCode);

            if(depCourse == null){
                return NotFound();
            }

            var lecturer = await _lecturerDepDetailsRepository.GetLecturerDepDetailAsync(depCourse.DepartmentName, CurrentTC);
            if(lecturer == null){
                return Unauthorized("You're not registered on this department. If this is a mistake, please contact the support.");
            }

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            var courseClass = await _courseClassRepository.GetCourseClassAsync(depCourse.CourseCode, uni.CurrentSchoolYear);

            if(courseClass == null){
                return BadRequest(ModelState);
            }

            if(courseClass.LecturerTC != CurrentTC){
                return Unauthorized();
            }

            StudentListDto list = new()
            {
                DepartmentName = depCourse.DepartmentName,
                CourseName = depCourse.CourseName,
                CourseCode = depCourse.CourseCode,
                NumberOfStudents = await _studentCourseDetailsRepository.GetStudentCountInCourse(depCourse.CourseCode, uni.CurrentSchoolYear),
                Students = []
            };

            var studentListDetails = await _studentCourseDetailsRepository.GetAllStudentsCourseDetails(depCourse.CourseCode, uni.CurrentSchoolYear);

            if(studentListDetails == null){
                return NotFound();
            }

            foreach(var student in studentListDetails){
                var studentAcc = await _studentAccountRepository.GetStudentAccountByTCAsync(student.TC);
                var studentDepDetails = await _studentDepDetailsRepository.GetStudentDepDetailAsync(student.TC, depCourse.DepartmentName);
                StudentDto dto = new()
                {
                    StudentName = studentAcc.FirstName + " " + studentAcc.LastName,
                    SSN = studentAcc.SSN,
                    Year = (studentDepDetails.CurrentSemester+1)/2,
                    State = student.State,
                    AttendanceFulfilled = student.AttendanceFulfilled,
                    MidTerm = student.MidTerm,
                    Final = student.Final,
                    Complement = student.Complement,
                    Grade = student.Grade
                };
                list.Students.Add(dto);
            }
            
            return Ok(list);
        }
        [HttpPut("University/Faculty/Department/Course/Student/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStudentCourseDetails([FromQuery] String DepName, [FromQuery] String CourseName, [FromQuery] String TC, [FromBody] StudentCourseDetailsUpdateDto studentCourseDetailsUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(studentCourseDetailsUpdateDto.MidTerm != null && (studentCourseDetailsUpdateDto.MidTerm < 0 || studentCourseDetailsUpdateDto.MidTerm > 100 )){
                return BadRequest("Bad input on Mid Term value.");
            }

            if(studentCourseDetailsUpdateDto.Final != null && (studentCourseDetailsUpdateDto.Final < 0 || studentCourseDetailsUpdateDto.Final > 100 )){
                return BadRequest("Bad input on Final value.");
            }

            if(studentCourseDetailsUpdateDto.Complement != null && (studentCourseDetailsUpdateDto.Complement < 0 || studentCourseDetailsUpdateDto.Complement > 100 )){
                return BadRequest("Bad input on Complement value.");
            }

            var validDep = await _departmentRepository.GetDepartmentAsync(DepName);

            if(validDep == null){
                return BadRequest("Department doesn't exist");
            }

            var validCourse = await _courseRepository.GetCourseAsync(CourseName);

            if(validCourse == null){
                return BadRequest("Course doesn't exist");
            }

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(CourseName, DepName);
            if(depCourse == null){
                return BadRequest("Course is not given on this department");
            }

            if(depCourse.CourseCode != studentCourseDetailsUpdateDto.CourseCode){
                return BadRequest("Query CourseCode not the same as the body.");
            }

            var validStudent = await _studentAccountRepository.GetStudentAccountByTCAsync(studentCourseDetailsUpdateDto.TC);

            if(validStudent == null){
                return BadRequest("Student doesn't exist");
            }

            var studentDepDetails = await _studentDepDetailsRepository.GetStudentDepDetailAsync(studentCourseDetailsUpdateDto.TC, DepName);
            if(studentDepDetails == null){
                return BadRequest("Student is not registered on this department.");
            }

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            var validClass = await _courseClassRepository.GetCourseClassAsync(studentCourseDetailsUpdateDto.CourseCode, uni.CurrentSchoolYear);
            
            if(validClass == null){
                return BadRequest("Course is not opened.");
            }

            var studentCourseDetails = await _studentCourseDetailsRepository.GetStudentCourseDetails(studentCourseDetailsUpdateDto.CourseCode, TC, uni.CurrentSchoolYear);

            if(studentCourseDetails == null){
                return NotFound();
            }

            if(studentCourseDetails.ComplementRight == null && studentCourseDetails.Complement != null){
                return BadRequest("You can't post Complement points without entering Mid Terms and Final first.");
            }

            if(studentCourseDetails.ComplementRight == false && studentCourseDetails.Complement != null){
                return BadRequest("This student doesn't have the right to attend the Complement Exam.");
            }

            studentCourseDetails.AttendanceFulfilled = studentCourseDetailsUpdateDto.AttendanceFulfilled;
            studentCourseDetails.MidTerm = studentCourseDetailsUpdateDto.MidTerm;
            studentCourseDetails.Final = studentCourseDetailsUpdateDto.Final;
            studentCourseDetails.Complement = studentCourseDetailsUpdateDto.Complement;

            await UpdateGrade(studentCourseDetails, validClass);
            
            var updatedStudentCourseDetails = await _studentCourseDetailsRepository.UpdateStudentCourseDetailsAsync(studentCourseDetails);
            
            if(updatedStudentCourseDetails == null){
                return BadRequest();
            }

            return Ok(updatedStudentCourseDetails.ToStudentCourseDetailsDto(depCourse.CourseName, depCourse.TaughtSemester));
        }
        [HttpPut("University/Faculty/Department/Course/Student/Attendance/")]
        [Authorize(Roles = "Lecturer")]
        public async Task<IActionResult> SetStudentAttendance([FromBody] UpdateAttendanceDto updateAttendanceDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var depCourse = await _departmentCourseRepository.GetDeparmentCourseByCourseCodeAsync(updateAttendanceDto.CourseCode);
            if(depCourse == null){
                return BadRequest("Course is not given on this department");
            }
            
            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            var validClass = await _courseClassRepository.GetCourseClassAsync(updateAttendanceDto.CourseCode, uni.CurrentSchoolYear);
            if(validClass == null){
                return BadRequest("Course is not opened.");
            }

            var CurrentTC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);
            if(validClass.LecturerTC != CurrentTC){
                return Unauthorized();
            }

            var validStudent = await _studentAccountRepository.GetStudentAccountBySSNAsync(updateAttendanceDto.SSN);
            if(validStudent == null){
                return NotFound("Student not found");
            }

            var studentDepDetails = await _studentDepDetailsRepository.GetStudentDepDetailAsync(validStudent.TC, depCourse.DepartmentName);
            if(studentDepDetails == null){
                return BadRequest("Student is not registered on this department.");
            }

            var studentCourseDetails = await _studentCourseDetailsRepository.GetStudentCourseDetails(updateAttendanceDto.CourseCode, validStudent.TC, uni.CurrentSchoolYear);

            if(studentCourseDetails == null){
                return NotFound();
            }

            if(studentCourseDetails.AttendanceFulfilled == updateAttendanceDto.AttendanceFulfilled){
                return Ok();
            }

            studentCourseDetails.AttendanceFulfilled = updateAttendanceDto.AttendanceFulfilled;
            
            var updatedStudentCourseDetails = await _studentCourseDetailsRepository.UpdateStudentCourseDetailsAsync(studentCourseDetails);
            
            if(updatedStudentCourseDetails == null){
                return BadRequest();
            }

            //return Ok(updatedStudentCourseDetails.ToStudentCourseDetailsDto(depCourse.CourseName, depCourse.TaughtSemester));
            return Ok();
        }
        [HttpPut("University/Faculty/Department/Course/Student/MidTerm/")]
        [Authorize(Roles = "Lecturer")]
        public async Task<IActionResult> AddStudentMidTerm([FromBody] UpdateExamDto updateExamDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var depCourse = await _departmentCourseRepository.GetDeparmentCourseByCourseCodeAsync(updateExamDto.CourseCode);
            if(depCourse == null){
                return BadRequest("Course not found. Bad Course Code.");
            }

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            var validClass = await _courseClassRepository.GetCourseClassAsync(updateExamDto.CourseCode, uni.CurrentSchoolYear);
            
            if(validClass == null){
                return BadRequest("Course is not opened.");
            }
            var CurrentTC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);
            if(validClass.LecturerTC != CurrentTC){
                return Unauthorized();
            }

            var validStudent = await _studentAccountRepository.GetStudentAccountBySSNAsync(updateExamDto.SSN);

            if(validStudent == null){
                return NotFound("Student not found");
            }

            if(updateExamDto.Points != null && (updateExamDto.Points < 0 || updateExamDto.Points > 100 )){
                return BadRequest("Points must be between 0 and 100.");
            }

            var studentDepDetails = await _studentDepDetailsRepository.GetStudentDepDetailAsync(validStudent.TC, depCourse.DepartmentName);
            if(studentDepDetails == null){
                return BadRequest("Student is not registered on this department.");
            }

            var studentCourseDetails = await _studentCourseDetailsRepository.GetStudentCourseDetails(updateExamDto.CourseCode, validStudent.TC, uni.CurrentSchoolYear);
            if(studentCourseDetails == null){
                return NotFound();
            }

            studentCourseDetails.MidTermAnnouncment = DateTime.Now;
            studentCourseDetails.MidTerm = updateExamDto.Points;

            await UpdateGrade(studentCourseDetails, validClass);
            
            var updatedStudentCourseDetails = await _studentCourseDetailsRepository.UpdateStudentCourseDetailsAsync(studentCourseDetails);
            
            if(updatedStudentCourseDetails == null){
                return BadRequest();
            }

            return Ok(updatedStudentCourseDetails.ToStudentCourseDetailsDto(depCourse.CourseName, depCourse.TaughtSemester));
        }
        [HttpPut("University/Faculty/Department/Course/Student/Final/")]
        [Authorize(Roles = "Lecturer")]
        public async Task<IActionResult> AddStudentFinal([FromBody] UpdateExamDto updateExamDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var depCourse = await _departmentCourseRepository.GetDeparmentCourseByCourseCodeAsync(updateExamDto.CourseCode);
            if(depCourse == null){
                return BadRequest("Course not found. Bad Course Code.");
            }

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            var validClass = await _courseClassRepository.GetCourseClassAsync(updateExamDto.CourseCode, uni.CurrentSchoolYear);
            
            if(validClass == null){
                return BadRequest("Course is not opened.");
            }
            var CurrentTC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);
            if(validClass.LecturerTC != CurrentTC){
                return Unauthorized();
            }

            var validStudent = await _studentAccountRepository.GetStudentAccountBySSNAsync(updateExamDto.SSN);

            if(validStudent == null){
                return NotFound("Student not found");
            }

            var studentDepDetails = await _studentDepDetailsRepository.GetStudentDepDetailAsync(validStudent.TC, depCourse.DepartmentName);
            if(studentDepDetails == null){
                return BadRequest("Student is not registered on this department.");
            }

            var studentCourseDetails = await _studentCourseDetailsRepository.GetStudentCourseDetails(updateExamDto.CourseCode, validStudent.TC, uni.CurrentSchoolYear);
            if(studentCourseDetails == null){
                return NotFound();
            }

            if(studentCourseDetails.MidTerm == null){
                return BadRequest("Cannot enter Final Exam's points without entering MidTerm's first.");
            }

            if(studentCourseDetails.AttendanceFulfilled == null){
                return BadRequest("Cannot enter Final Exam's points without entering Attendance first.");
            }

            studentCourseDetails.FinalAnnouncment = DateTime.Now;
            studentCourseDetails.Final = updateExamDto.Points;

            await UpdateGrade(studentCourseDetails, validClass);
            
            var updatedStudentCourseDetails = await _studentCourseDetailsRepository.UpdateStudentCourseDetailsAsync(studentCourseDetails);
            
            if(updatedStudentCourseDetails == null){
                return BadRequest();
            }

            return Ok(updatedStudentCourseDetails.ToStudentCourseDetailsDto(depCourse.CourseName, depCourse.TaughtSemester));
        }
        [HttpPut("University/Faculty/Department/Course/Student/Complement/")]
        [Authorize(Roles = "Lecturer")]
        public async Task<IActionResult> AddStudentComplement([FromBody] UpdateExamDto updateExamDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var depCourse = await _departmentCourseRepository.GetDeparmentCourseByCourseCodeAsync(updateExamDto.CourseCode);
            if(depCourse == null){
                return BadRequest("Course not found. Bad Course Code.");
            }

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            var validClass = await _courseClassRepository.GetCourseClassAsync(updateExamDto.CourseCode, uni.CurrentSchoolYear);
            
            if(validClass == null){
                return BadRequest("Course is not opened.");
            }
            var CurrentTC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);
            if(validClass.LecturerTC != CurrentTC){
                return Unauthorized();
            }

            var validStudent = await _studentAccountRepository.GetStudentAccountBySSNAsync(updateExamDto.SSN);

            if(validStudent == null){
                return NotFound("Student not found");
            }

            var studentDepDetails = await _studentDepDetailsRepository.GetStudentDepDetailAsync(validStudent.TC, depCourse.DepartmentName);
            if(studentDepDetails == null){
                return BadRequest("Student is not registered on this department.");
            }

            var studentCourseDetails = await _studentCourseDetailsRepository.GetStudentCourseDetails(updateExamDto.CourseCode, validStudent.TC, uni.CurrentSchoolYear);
            if(studentCourseDetails == null){
                return NotFound();
            }

            if(studentCourseDetails.ComplementRight == null){
                return BadRequest("You can't post Complement points without entering Mid Terms and Final first.");
            }

            if(studentCourseDetails.ComplementRight == false && studentCourseDetails.Complement != null){
                return BadRequest("This student doesn't have the right to attend the Complement Exam.");
            }

            studentCourseDetails.ComplementAnnouncment = DateTime.Now;
            studentCourseDetails.Complement = updateExamDto.Points;

            await UpdateGrade(studentCourseDetails, validClass);
            
            var updatedStudentCourseDetails = await _studentCourseDetailsRepository.UpdateStudentCourseDetailsAsync(studentCourseDetails);
            
            if(updatedStudentCourseDetails == null){
                return BadRequest();
            }

            return Ok(updatedStudentCourseDetails.ToStudentCourseDetailsDto(depCourse.CourseName, depCourse.TaughtSemester));
        }
        [HttpDelete("University/Faculty/Department/Course/Student/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStudentDepDetails([FromQuery] String DepName, [FromQuery] String CourseName, [FromQuery] String TC){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(CourseName, DepName);
            if(depCourse == null){
                return BadRequest("Course is not taught at this department.");
            }

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            if(uni == null){
                return StatusCode(500, "Failed to get university data.");
            }

            var result = await _studentCourseDetailsRepository.DeleteStudentCourseDetailsAsync(depCourse.CourseCode, TC, uni.CurrentSchoolYear);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
        private void CalculateGrade(StudentCourseDetails studentCourseDetails, int MidTermValue, int FinalValue, int finalNote){     
            float? final;
            if(finalNote == 0){
                final = studentCourseDetails.Final;
            }else{
                final = studentCourseDetails.Complement;
            }

            if(final == null || studentCourseDetails.MidTerm == null)
                return;
            
            float? points = final*((float)FinalValue/100) + studentCourseDetails.MidTerm*((float)MidTermValue/100);
            if(points >= 90){
                studentCourseDetails.Grade = 4;
            }else if(points >= 85){
                studentCourseDetails.Grade = (float)3.5;
            }else if(points >= 80){
                studentCourseDetails.Grade = 3;
            }else if(points >= 70){
                studentCourseDetails.Grade = (float)2.5;
            }else if(points >= 60){
                studentCourseDetails.Grade = 2;
            }else if(points >= 55){
                studentCourseDetails.Grade = (float)1.5;
            }else if(points >= 50){
                studentCourseDetails.Grade = 1;
            }else if(points >= 40){
                studentCourseDetails.Grade = (float)0.5;
            }else{
                studentCourseDetails.Grade = 0;
            }
            
            if(studentCourseDetails.Grade < 1){
                studentCourseDetails.State = "Failed";
                studentCourseDetails.ComplementRight = true;
            }else if(studentCourseDetails.Grade > 1 && studentCourseDetails.Grade < 2){
                studentCourseDetails.State = "Partially Passed";
                studentCourseDetails.ComplementRight = false;
            }else{
                studentCourseDetails.State = "Passed";
                studentCourseDetails.ComplementRight = false;
            }
        }
        private async Task<bool> UpdateGrade(StudentCourseDetails studentCourseDetails, CourseClass validClass){
            if(studentCourseDetails.AttendanceFulfilled != null ){
                if(studentCourseDetails.AttendanceFulfilled == false){
                    studentCourseDetails.State = "Failed";
                    studentCourseDetails.Grade = 0;
                    studentCourseDetails.ComplementRight = false;
                }else if(studentCourseDetails.ComplementRight != null && studentCourseDetails.ComplementRight == true && studentCourseDetails.Complement != null){
                    CalculateGrade(studentCourseDetails, validClass.MidTermValue, validClass.FinalValue, 1);
                }else if(studentCourseDetails.Final != null && studentCourseDetails.MidTerm != null){
                    if(studentCourseDetails.Final < 50){
                        studentCourseDetails.State = "Failed";
                        studentCourseDetails.Grade = 0;
                        studentCourseDetails.ComplementRight = true;
                    }else{
                        CalculateGrade(studentCourseDetails, validClass.MidTermValue, validClass.FinalValue, 0);
                    }   
                }
                await UpdateGNO(studentCourseDetails.DepartmentName, studentCourseDetails.TC);
            }
            return true;
        }
        [HttpGet("University/Faculty/Department/Course/Student/Results")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetResult([FromQuery] String courseCode){
            var validCourse = await _departmentCourseRepository.GetDeparmentCourseByCourseCodeAsync(courseCode);
            if(validCourse == null)
            {
                return BadRequest("No valid course with that course code");
            }

            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            if(uni == null){
                return StatusCode(500, "Failed to get university data.");
            }

            var studentCourseDetails = await _studentCourseDetailsRepository.GetStudentCourseDetails(courseCode, TC);
            if(studentCourseDetails == null){
                return NotFound();
            }

            ICollection<ExamResultsDto> results = [];
            foreach(var courseDetail in studentCourseDetails){
                var cClass = await _courseClassRepository.GetCourseClassAsync(courseDetail.CourseCode, courseDetail.SchoolYear);
                var lecturer = await _lecturerAccountRepository.GetLecturerAccountByTCAsync(cClass.LecturerTC);
                var averages = new float[3];

                var studentsCourseDetails = await _studentCourseDetailsRepository.GetAllStudentsCourseDetails(courseDetail.CourseCode, courseDetail.SchoolYear);
                averages[0] = calcAverage(studentsCourseDetails, "MidTerm");
                averages[1] = calcAverage(studentsCourseDetails, "Final");
                averages[2] = calcAverage(studentsCourseDetails, "Complement");
                
                var dto = courseDetail.ToExamResultsDto(lecturer.FirstName + " " + lecturer.LastName, averages);
                results.Add(dto);
            }

            return Ok(results);
        }
        private float calcAverage(ICollection<StudentCourseDetails> studentsCourseDetails, String Type){
            int totalPoints = 0;
            int totalStudent = 0;
            if(Type == "MidTerm"){
                foreach(var student in studentsCourseDetails){
                    if(student.MidTerm != null){
                        totalStudent++;
                        totalPoints += student.MidTerm.Value;
                    }
                }
            }else if(Type == "Final"){
                foreach(var student in studentsCourseDetails){
                    if(student.Final != null){
                        totalStudent++;
                        totalPoints += student.Final.Value;
                    }
                }
            }else if(Type == "Complement"){
                foreach(var student in studentsCourseDetails){
                    if(student.Complement != null){
                        totalStudent++;
                        totalPoints += student.Complement.Value;
                    }
                }
            }else {
                return -1;
            }

            if(totalStudent == 0)
                return 0;
            else
                return (float)totalPoints/totalStudent;
        }
        private async Task<bool> UpdateGNO(String DepartmentName, String TC){
            float? upper = 0;
            float? lower = 0;
            var courseDetails = await _studentCourseDetailsRepository.GetStudentsAllCourseDetails(DepartmentName, TC);
        
            foreach(var courseDetail in courseDetails){
                if(courseDetail.State == "Passed" || courseDetail.State == "Failed" || courseDetail.State == "Partially Passed"){
                    var courseClass = await _courseClassRepository.GetCourseClassAsync(courseDetail.CourseCode, courseDetail.SchoolYear);
                    upper += courseDetail.Grade * courseClass.AKTS;
                    lower += courseClass.AKTS;
                }
            }

            if(lower != null && upper != null && lower != 0){
                var studentDepDetails = await _studentDepDetailsRepository.GetStudentDepDetailAsync(TC, DepartmentName);
                if(studentDepDetails == null){
                    return false;
                } 
                studentDepDetails.Gno = (float) upper/lower;
                return true;
            }

            return false;
        }
    }
}