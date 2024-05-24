
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
        public CourseClassController(ICourseClassRepository courseClassRepository, IDepartmentCourseRepository departmentCourseRepository, IDepartmentRepository departmentRepository){
            _courseClassRepository = courseClassRepository;
            _departmentCourseRepository = departmentCourseRepository;
            _departmentRepository = departmentRepository;
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

            var courseClass = await _courseClassRepository.GetCourseClassAsync(DepName, CourseName, depCourse.Department.Faculty.University.CurrentSchoolYear);
            
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

            var coursesClass = await _courseClassRepository.GetSpecificCourseClasses(DepName, dep.Faculty.University.CurrentSchoolYear);
            
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
            
            var courseClass = await _courseClassRepository.AddCourseClassAsync(courseClassPostDto.ToCourseClass(depCourse.Department.Faculty.University.CurrentSchoolYear));
            
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

            var courseClass = await _courseClassRepository.GetCourseClassAsync(DepName, CourseName, depCourse.Department.Faculty.University.CurrentSchoolYear);
            
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

            var result = await _courseClassRepository.DeleteCourseClassAsync(DepName, CourseName, depCourse.Department.Faculty.University.CurrentSchoolYear);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
    }
}