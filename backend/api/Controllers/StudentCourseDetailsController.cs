
using api.DTO.StudentCourseDetails;
using api.Interfaces;
using api.Mappers;
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

        public StudentCourseDetailsController(IStudentCourseDetailsRepostiory studentCourseDetailsRepostiory, ICourseClassRepository courseClassRepository, IStudentAccountRepository studentAccountRepository, IDepartmentRepository departmentRepository, ICourseRepository courseRepository, IUniversityRepository universityRepository){
            _studentCourseDetailsRepository = studentCourseDetailsRepostiory;
            _courseClassRepository = courseClassRepository;
            _studentAccountRepository = studentAccountRepository;
            _departmentRepository = departmentRepository;
            _courseRepository = courseRepository;
            _universityRepository = universityRepository;
        }
        [HttpGet("University/Faculty/Departments/Student/Courses/Details")]
        public async Task<IActionResult> GetStudentCoursesDetails([FromQuery] String DepName, [FromQuery] String TC){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);
            
            var coursesDetails = await _studentCourseDetailsRepository.GetStudentsAllCourseDetails(DepName, TC);
            
            return Ok(coursesDetails);
        }
        [HttpGet("University/Faculty/Departments/Course/Student/Details")]
        public async Task<IActionResult> GetStudentCourseDetails([FromQuery] String DepName, [FromQuery] String Course, [FromQuery] String TC){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);
            
            var courseDetails = await _studentCourseDetailsRepository.GetStudentCourseDetails(DepName, Course, TC);
            
            return Ok(courseDetails.ToStudentCourseDetailsDto());
        }
        [HttpGet("University/Faculty/Departments/Course/Students/Details")]
        public async Task<IActionResult> GetCoursesStudentsDetails([FromQuery] String DepName, [FromQuery] String Course){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var coursesDetails = await _studentCourseDetailsRepository.GetAllStudentsCourseDetails(DepName, Course);
            
            return Ok(coursesDetails);
        }
        [HttpPost("University/Faculty/Department/Course/Student/Details")]
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

            var validCourse = await _courseRepository.GetCourseAsync(studentCourseDetailsPostDto.CourseName);

            if(validCourse == null){
                return BadRequest("Course doesn't exist");
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

            var validCourse = await _courseRepository.GetCourseAsync(studentCourseDetailsUpdateDto.CourseName);

            if(validCourse == null){
                return BadRequest("Course doesn't exist");
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