
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using api.DTO.StudentCourseDetails;
using api.Interfaces;
using api.Mappers;
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
            
            return Ok(coursesDetails.ToStudentCourseDetailsDto());
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

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            
            var courseClass = await _courseClassRepository.GetCourseClassAsync(DepName, Course, uni.CurrentSchoolYear);

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
            
            var courseDetails = await _studentCourseDetailsRepository.GetStudentCourseDetails(DepName, Course, TC);

            if(courseDetails == null){
                return NotFound();
            }
            
            return Ok(courseDetails.ToStudentCourseDetailsDto());
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

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            var courseClass = await _courseClassRepository.GetCourseClassAsync(DepName, Course, uni.CurrentSchoolYear);

            if(courseClass == null){
                return BadRequest(ModelState);
            }

            if(courseClass.LecturerTC != CurrentTC){
                return Unauthorized();
            }
            
            var coursesDetails = await _studentCourseDetailsRepository.GetAllStudentsCourseDetails(DepName, Course);

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

            var validCourse = await _courseRepository.GetCourseAsync(studentCourseDetailsPostDto.CourseName);

            if(validCourse == null){
                return BadRequest("Course doesn't exist");
            }

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(studentCourseDetailsPostDto.CourseName, studentCourseDetailsPostDto.DepartmentName);
            if(depCourse == null){
                return BadRequest("Course is not taught at this department.");
            }

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            var validClass = await _courseClassRepository.GetCourseClassAsync(studentCourseDetailsPostDto.DepartmentName, studentCourseDetailsPostDto.CourseName, uni.CurrentSchoolYear);
            
            if(validClass == null){
                return BadRequest("Course Class doesn't exist");
            }

            var studentCourseDetails = await _studentCourseDetailsRepository.CreateStudentCourseDetails(studentCourseDetailsPostDto.ToStudentCourseDetails(uni.CurrentSchoolYear));
            
            if(studentCourseDetails == null){
                return BadRequest();
            }

            return Ok(studentCourseDetails.ToStudentCourseDetailsDto());
        }
        [HttpPut("University/Faculty/Department/Course/Student/Details")]
        [Authorize(Roles = "Lecturer")]
        public async Task<IActionResult> UpdateStudentCourseDetails([FromQuery] String DepName, [FromQuery] String CourseName, [FromQuery] String TC, [FromBody] StudentCourseDetailsUpdateDto studentCourseDetailsUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(DepName != studentCourseDetailsUpdateDto.DepartmentName || CourseName != studentCourseDetailsUpdateDto.CourseName || TC != studentCourseDetailsUpdateDto.TC){
                return BadRequest(ModelState);
            }

            var validStudent = await _studentAccountRepository.GetStudentAccountByTCAsync(studentCourseDetailsUpdateDto.TC);

            if(validStudent == null){
                return BadRequest("Student doesn't exist");
            }

            var validDep = await _departmentRepository.GetDepartmentAsync(studentCourseDetailsUpdateDto.DepartmentName);

            if(validDep == null){
                return BadRequest("Department doesn't exist");
            }

            var studentDepDetails = await _studentDepDetailsRepository.GetStudentDepDetailAsync(studentCourseDetailsUpdateDto.TC, studentCourseDetailsUpdateDto.DepartmentName);
            if(studentDepDetails == null){
                return BadRequest("Student is not registered on this department.");
            }

            var validCourse = await _courseRepository.GetCourseAsync(studentCourseDetailsUpdateDto.CourseName);

            if(validCourse == null){
                return BadRequest("Course doesn't exist");
            }

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(studentCourseDetailsUpdateDto.CourseName, studentCourseDetailsUpdateDto.DepartmentName);
            if(depCourse == null){
                return BadRequest("Course is not taught at this department.");
            }

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            var validClass = await _courseClassRepository.GetCourseClassAsync(studentCourseDetailsUpdateDto.DepartmentName, studentCourseDetailsUpdateDto.CourseName, uni.CurrentSchoolYear);
            
            if(validClass == null){
                return BadRequest("Course Class doesn't exist");
            }

            var studentCourseDetails = await _studentCourseDetailsRepository.GetStudentCourseDetails(DepName, CourseName, TC);

            if(studentCourseDetails == null){
                return NotFound();
            }

            studentCourseDetails.State = studentCourseDetailsUpdateDto.State;
            studentCourseDetails.AttendanceFulfilled = studentCourseDetailsUpdateDto.AttendanceFulfilled;
            studentCourseDetails.MidTerm = studentCourseDetailsUpdateDto.MidTerm;
            studentCourseDetails.Final = studentCourseDetailsUpdateDto.Final;
            studentCourseDetails.Grade = studentCourseDetailsUpdateDto.Grade;
            
            var updatedStudentCourseDetails = await _studentCourseDetailsRepository.UpdateStudentCourseDetailsAsync(studentCourseDetails);
            
            if(updatedStudentCourseDetails == null){
                return BadRequest();
            }

            return Ok(updatedStudentCourseDetails.ToStudentCourseDetailsDto());
        }
        [HttpDelete("University/Faculty/Department/Course/Student/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStudentDepDetails([FromQuery] String DepName, [FromQuery] String CourseName, [FromQuery] String TC){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _studentCourseDetailsRepository.DeleteStudentCourseDetailsAsync(DepName, CourseName, TC);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
    }
}