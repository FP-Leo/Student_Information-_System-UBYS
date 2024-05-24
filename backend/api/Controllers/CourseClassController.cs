
using api.DTO.CourseClass;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CourseClassController : ControllerBase
    {
        private readonly ICourseClassRepository _courseClassRepository;
        private readonly IDepartmentCourseRepository _departmentCourseRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUniversityRepository _universityRepository;
        public CourseClassController(ICourseClassRepository courseClassRepository, IDepartmentCourseRepository departmentCourseRepository, IDepartmentRepository departmentRepository, IUniversityRepository universityRepository){
            _courseClassRepository = courseClassRepository;
            _departmentCourseRepository = departmentCourseRepository;
            _departmentRepository = departmentRepository;
            _universityRepository = universityRepository;
        }
        [HttpGet("University/Faculty/Department/Course/Class")]
        public async Task<IActionResult> GetCourseClass([FromQuery] String DepName, [FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(CourseName, DepName);

            if(depCourse == null){
                return NotFound();
            }

            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);

            var courseClass = await _courseClassRepository.GetCourseClassAsync(DepName, CourseName, uni.CurrentSchoolYear);
            
            if(courseClass == null){
                return NotFound();
            }

            return Ok(courseClass.ToCourseClassDto());
        }
        [HttpGet("University/Faculty/Department/Courses/Class")]
        public async Task<IActionResult> GetCoursesClass([FromQuery] String DepName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var dep = await _departmentRepository.GetDepartmentAsync(DepName);

            if(dep == null){
                return NotFound();
            }
            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);

            var coursesClass = await _courseClassRepository.GetSpecificCourseClasses(DepName, uni.CurrentSchoolYear);
            
            if(coursesClass == null){
                return NotFound();
            }

            return Ok(coursesClass);
        }
        [HttpPost("University/Faculty/Department/Course/Class")]
        public async Task<IActionResult> AddCourseClass([FromBody] CourseClassPostDto courseClassPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(courseClassPostDto.CourseName, courseClassPostDto.DepartmentName);

            if(depCourse == null){
                return NotFound();
            }

            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            
            var courseClass = await _courseClassRepository.AddCourseClassAsync(courseClassPostDto.ToCourseClass(uni.CurrentSchoolYear));
            
            if(courseClass == null){
                return BadRequest();
            }

            return Ok(courseClass.ToCourseClassDto());
        }
        [HttpPut("University/Faculty/Department/Course/Class")]
        public async Task<IActionResult> UpdateCourseClass([FromQuery] String DepName, [FromQuery] String CourseName, [FromBody] CourseClassUpdateDto courseClassUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(DepName != courseClassUpdateDto.DepartmentName || CourseName != courseClassUpdateDto.CourseName){
                return BadRequest(ModelState);
            }

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(courseClassUpdateDto.CourseName, courseClassUpdateDto.DepartmentName);

            if(depCourse == null){
                return NotFound();
            }

            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);

            var courseClass = await _courseClassRepository.GetCourseClassAsync(DepName, CourseName, uni.CurrentSchoolYear);
            
            if(courseClass == null){
                return NotFound();
            }

            courseClass.LecturerTC = courseClassUpdateDto.LecturerTC;
            courseClass.HourPerWeek = courseClassUpdateDto.HourPerWeek;
            courseClass.AKTS = courseClassUpdateDto.AKTS;
            courseClass.Kredi = courseClassUpdateDto.Kredi;
            courseClass.MidTermValue = courseClassUpdateDto.MidTermValue;
            courseClass.FinalValue = courseClassUpdateDto.FinalValue;
            
            var updatedCourseClass = await _courseClassRepository.UpdateCourseClassAsync(courseClass);
            
            if(updatedCourseClass == null){
                return StatusCode(500);
            }

            return Ok(updatedCourseClass.ToCourseClassDto());
        }
        [HttpDelete("University/Faculty/Department/Course/Class")]
        public async Task<IActionResult> DeleteCourseClass([FromQuery] String DepName, [FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(CourseName, DepName);

            if(depCourse == null){
                return NotFound();
            }

            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);

            var result = await _courseClassRepository.DeleteCourseClassAsync(DepName, CourseName, uni.CurrentSchoolYear);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
    }
}