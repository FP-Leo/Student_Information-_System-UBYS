using api.DTO.DeparmentCourse;
using api.DTO.DepartmentCourse;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DepartmentCourseController: ControllerBase
    {
        private readonly IDepartmentCourseRepository _departmentCourseRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICourseRepository _courseRepository;
        public DepartmentCourseController(IDepartmentCourseRepository courseDepRepository, IDepartmentRepository departmentRepository, ICourseRepository courseRepository){
            _departmentCourseRepository = courseDepRepository;
            _departmentRepository = departmentRepository;
            _courseRepository = courseRepository;
        }

        [HttpGet("University/Faculty/Department/Course/")]
        public async Task<IActionResult> GetDepCourseByCourseIdAndDepId([FromQuery] String DepName, [FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var course = await _departmentCourseRepository.CourseDetailsByCourseAndDepNameAsync(CourseName, DepName);

            if(course == null){
                return NotFound();
            }

            return Ok(course.ToDepartmentCourseDto());
        }
        [HttpGet("University/Faculty/Departments/Course")]
        public async Task<IActionResult> GetDepartmentsOfCourse([FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var course = await _departmentCourseRepository.GetDepartmentsOfCourseByCourseNameAsync(CourseName);

            if(course == null){
                return NotFound();
            }

            return Ok(course);
        }
        [HttpGet("University/Faculty/Department/Courses/")]
        public async Task<IActionResult> GetCoursesOfDepartment([FromQuery] String DepName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var course = await _departmentCourseRepository.GetDepartmentCoursesAsync(DepName);

            if(course == null){
                return NotFound();
            }

            return Ok(course);
        }
        [HttpPost("University/Faculty/Department/Course")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCourseToDepartment([FromBody] DepartmentCoursePostDto coursePostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var validDepartment = await _departmentRepository.GetDepartmentAsync(coursePostDto.DepartmentName);

            if(validDepartment == null){
                return NotFound("Department not found!");
            }

            var validCourse = await _courseRepository.GetCourseAsync(coursePostDto.CourseName);

            if(validCourse == null){
                return NotFound("Course not found!");
            }
            
            var depsDetails = await _departmentCourseRepository.AddCourseToDepAsync(coursePostDto.ToDepartmentCourse());
            
            if(depsDetails == null){
                return BadRequest();
            }

            return Ok(depsDetails.ToDepartmentCourseDto());
        }
        [HttpPut("University/Faculty/Department/Course")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCourseOfDepartment([FromQuery] String DepName, [FromQuery] String CourseName, [FromBody] DepartmentCourseUpdateDto departmentCourseUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var depCourse = await _departmentCourseRepository.CourseDetailsByCourseAndDepNameAsync(CourseName, DepName);

            if(depCourse == null){
                return BadRequest();
            }

            if(departmentCourseUpdateDto.CourseName != CourseName || departmentCourseUpdateDto.DepartmentName != DepName){
                return BadRequest();
            }

            depCourse.TaughtSemester = departmentCourseUpdateDto.TaughtSemester;
            depCourse.CourseDetailsId = departmentCourseUpdateDto.CourseDetailsId;
            
            var updatedDepCourse = await _departmentCourseRepository.UpdateDepsCourseAsync(depCourse);
            
            if(updatedDepCourse == null){
                return StatusCode(500);
            }

            return Ok(updatedDepCourse.ToDepartmentCourseDto());
        }
        [HttpDelete("University/Faculty/Deparment/Course")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCourseOfDepartment([FromQuery] String DepName, [FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _departmentCourseRepository.DeleteCourseFromDepAsync(CourseName, DepName);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
    }
}