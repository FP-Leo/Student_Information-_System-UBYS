using api.DTO.CourseClassDate;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CourseClassDateController : ControllerBase
    {
        private readonly ICourseClassDateRepository _courseClassDateRepo;
        private readonly IClassDateRepository _classDateRepo;
        private readonly IDepartmentCourseRepository _departmentCourseRepo;
        public CourseClassDateController(ICourseClassDateRepository courseClassDateRepository, IClassDateRepository classDateRepository, IDepartmentCourseRepository departmentCourseRepository){
            _courseClassDateRepo = courseClassDateRepository;
            _classDateRepo = classDateRepository;
            _departmentCourseRepo = departmentCourseRepository;
        }
        [HttpGet("University/Faculty/Department/Course/Class/Dates/")]
        public async Task<IActionResult> GetCourseClassDates([FromQuery] String DepartmentName, String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var depCourse = await _departmentCourseRepo.GetDeparmentCourseAsync(DepartmentName, CourseName);
            if(depCourse == null){
                return NotFound();
            }
            
            var courseClassDates = await _courseClassDateRepo.GetCourseClassDatesAsync(depCourse.CourseCode);

            if(courseClassDates == null){
                return BadRequest();
            }

            return Ok(await courseClassDates.ToCourseClassDatesDto(_classDateRepo));
        }
        [HttpPost("University/Faculty/Department/Course/Class/Dates/")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCourseClassDates([FromBody] CourseClassDatePostDto courseClassDatePostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ClassDates = courseClassDatePostDto.GetClassDates();

            if(ClassDates == null){
                return BadRequest();
            }

            foreach(var cls in ClassDates){
                var classDate = await _classDateRepo.GetClassDateIdAsync(cls.Day, cls.Time, cls.NumberOfClasses);
                if(classDate == null){
                    classDate = await _classDateRepo.CreateClassDateAsync(classDate);
                    if(classDate == null){
                        return StatusCode(500);
                    }
                }
                var courseClassDate = await _courseClassDateRepo.CreateCourseClassDateAsync(courseClassDatePostDto.ToCourseClassDate(classDate.Id));
                if(courseClassDate == null){
                    return StatusCode(500);
                }
            }

            return Ok();
        }
        [HttpDelete("University/Faculty/Department/Course/Class/Dates/")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCourseClassDates([FromQuery] String DepartmentName, [FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var depCourse = await _departmentCourseRepo.GetDeparmentCourseAsync(DepartmentName, CourseName);
            if(depCourse == null){
                return NotFound();
            }

            var result = await _courseClassDateRepo.GetCourseClassDatesAsync(depCourse.CourseCode);

            if(result == null){
                return BadRequest();
            }

            foreach(var cls in result){
                var deleted = await _courseClassDateRepo.DeleteCourseClassDateAsync(cls);
                if(deleted == null){
                    return StatusCode(500);
                }
            }

            return NoContent();
        }
        [HttpDelete("University/Faculty/Department/Course/Class/Date/")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCourseClassDate([FromBody] CourseClassDateDeleteDto courseClassDateDeleteDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(courseClassDateDeleteDto == null){
                return BadRequest();
            }

            var classId = await _classDateRepo.GetClassDateIdAsync(courseClassDateDeleteDto.Day, courseClassDateDeleteDto.Time, courseClassDateDeleteDto.NumberOfClasses);
            
            if(classId == null){
                return NotFound("Class Date not found");
            }

            var courseClassDate = await _courseClassDateRepo.GetCourseClassDateAsync(courseClassDateDeleteDto.CourseCode, classId.Id);

            if(courseClassDate == null){
                return NotFound("Course is not given at that date.");
            }

            var result = await _courseClassDateRepo.DeleteCourseClassDateAsync(courseClassDate);

            if(result == null){
                return StatusCode(500);
            }

            return NoContent();
        }
    }
}