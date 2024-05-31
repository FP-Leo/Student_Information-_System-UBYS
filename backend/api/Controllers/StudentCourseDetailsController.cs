
using System.IdentityModel.Tokens.Jwt;
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
        private readonly ILecturerDepDetailsRepository _lecturerDepDetailsRepository;
        private readonly IDepartmentCourseRepository _departmentCourseRepository;
        public StudentCourseDetailsController(IStudentCourseDetailsRepostiory studentCourseDetailsRepostiory, ICourseClassRepository courseClassRepository, IStudentAccountRepository studentAccountRepository, IDepartmentRepository departmentRepository, ICourseRepository courseRepository, IUniversityRepository universityRepository, IStudentDepDetailsRepository studentDepDetailsRepository, ILecturerDepDetailsRepository lecturerDepDetailsRepository, IDepartmentCourseRepository departmentCourseRepository){
            _studentCourseDetailsRepository = studentCourseDetailsRepostiory;
            _courseClassRepository = courseClassRepository;
            _studentAccountRepository = studentAccountRepository;
            _departmentRepository = departmentRepository;
            _courseRepository = courseRepository;
            _universityRepository = universityRepository;
            _studentDepDetailsRepository = studentDepDetailsRepository;
            _lecturerDepDetailsRepository = lecturerDepDetailsRepository;
            _departmentCourseRepository = departmentCourseRepository;
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
            
            var courseDetails = await _studentCourseDetailsRepository.GetStudentCourseDetails(depCourse.CourseCode, TC);

            if(courseDetails == null){
                return NotFound();
            }
            
            return Ok(courseDetails.ToStudentCourseDetailsDto(depCourse.CourseName, depCourse.TaughtSemester));
        }
        [HttpGet("University/Faculty/Departments/Course/Students/Details")]
        [Authorize(Roles = "Lecturer")]
        public async Task<IActionResult> GetCoursesStudentsDetails([FromQuery] String DepName, [FromQuery] String Course){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CurrentTC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            var lecturer = await _lecturerDepDetailsRepository.GetLecturerDepDetailAsync(DepName, CurrentTC);
            if(lecturer == null){
                return Unauthorized("You're not registered on this department. If this is a mistake, please contact the support.");
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

            if(courseClass.LecturerTC != CurrentTC){
                return Unauthorized();
            }
            
            var coursesDetails = await _studentCourseDetailsRepository.GetAllStudentsCourseDetails(depCourse.CourseCode);

            if(coursesDetails == null){
                return NotFound();
            }
            
            return Ok(coursesDetails);
        }
        [HttpPost("University/Faculty/Department/Course/Student/Details")]
        [Authorize(Roles = "Advisor")]
        public async Task<IActionResult> AddStudentCourseDetails([FromBody] StudentCourseDetailsPostDto studentCourseDetailsPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validStudent = await _studentAccountRepository.GetStudentAccountByTCAsync(studentCourseDetailsPostDto.TC);

            if(validStudent == null){
                return BadRequest("Student doesn't exist");
            }

            var validDep = await _departmentRepository.GetDepartmentAsync(studentCourseDetailsPostDto.DepartmentName);

            if(validDep == null){
                return BadRequest("Department doesn't exist");
            }

            var studentDepDetails = await _studentDepDetailsRepository.GetStudentDepDetailAsync(studentCourseDetailsPostDto.TC, studentCourseDetailsPostDto.DepartmentName);
            if(studentDepDetails == null){
                return BadRequest("Student is not registered on this department.");
            }

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseByCourseCodeAsync(studentCourseDetailsPostDto.CourseCode);
            if(depCourse == null){
                return BadRequest("Course is not taught at this department.");
            }

            if(depCourse.DepartmentName != studentCourseDetailsPostDto.DepartmentName){
                return BadRequest("Course Code and Department don't match");
            }

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            var validClass = await _courseClassRepository.GetCourseClassAsync(studentCourseDetailsPostDto.CourseCode, uni.CurrentSchoolYear);
            
            if(validClass == null){
                return BadRequest("Course Class doesn't exist");
            }

            var prevStudentCourseDetails = await _studentCourseDetailsRepository.GetStudentCourseDetails(studentCourseDetailsPostDto.CourseCode, studentCourseDetailsPostDto.TC);

            var studentCourseDetails = await _studentCourseDetailsRepository.CreateStudentCourseDetails(studentCourseDetailsPostDto.ToStudentCourseDetails(uni.CurrentSchoolYear));
            
            if(studentCourseDetails == null){
                return BadRequest();
            }

            if(prevStudentCourseDetails != null){
                studentCourseDetails.AttendanceFulfilled = prevStudentCourseDetails.AttendanceFulfilled;
                prevStudentCourseDetails.State = "Re-Attended";
            }

            return Ok(studentCourseDetails.ToStudentCourseDetailsDto(depCourse.CourseName, depCourse.TaughtSemester));
        }
        [HttpPut("University/Faculty/Department/Course/Student/Details")]
        [Authorize(Roles = "Lecturer")]
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

            var studentCourseDetails = await _studentCourseDetailsRepository.GetStudentCourseDetails(studentCourseDetailsUpdateDto.CourseCode, TC);

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

            if(studentCourseDetails.AttendanceFulfilled != null ){
                if(studentCourseDetails.AttendanceFulfilled == false){
                    studentCourseDetails.State = "Failed";
                    studentCourseDetails.ComplementRight = false;
                }else if(studentCourseDetails.ComplementRight != null && studentCourseDetails.ComplementRight == true && studentCourseDetails.Complement != null){
                    CalculateGrade(studentCourseDetails, validClass.MidTermValue, validClass.FinalValue, 1);
                }else if(studentCourseDetails.Final != null){
                    if(studentCourseDetails.Final < 50){
                        studentCourseDetails.State = "Failed";
                        studentCourseDetails.ComplementRight = true;
                    }else{
                        CalculateGrade(studentCourseDetails, validClass.MidTermValue, validClass.FinalValue, 0);
                    }   
                }
            }
            
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

            var result = await _studentCourseDetailsRepository.DeleteStudentCourseDetailsAsync(depCourse.CourseCode, TC);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
        private void CalculateGrade(StudentCourseDetails studentCourseDetails, int MidTermValue, int FinalValue, int? finalNote){
            
            if(finalNote == 0){
                finalNote = studentCourseDetails.Final;
            }else{
                finalNote = studentCourseDetails.Complement;
            }
            
            studentCourseDetails.Grade = finalNote*(FinalValue/100) + studentCourseDetails.MidTerm*(MidTermValue/100);
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
    }
}