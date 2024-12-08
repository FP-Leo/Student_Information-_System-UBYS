using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.Course;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.MappingProfiles;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CourseController: ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository){
            _courseRepository = courseRepository;
        }

        [HttpGet("Course/{Id:int}")]
        public async Task<IActionResult> GetCourse(int Id){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var course = await _courseRepository.GetCourseAsync(Id);

            if(course == null){
                return BadRequest();
            }

            return Ok(course.ToCourseDto());
        }
        [HttpGet("Course/{Name}")]
        public async Task<IActionResult> GetCourse(String Name){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var course = await _courseRepository.GetCourseAsync(Name);

            if(course == null){
                return BadRequest();
            }

            return Ok(course.ToCourseDto());
        }
        [HttpGet("Course")]
        public async Task<IActionResult> GetCourses(){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var course = await _courseRepository.GetCoursesAsync();

            if(course == null){
                return BadRequest();
            }

            return Ok(course);
        }
        [HttpPost("Course")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCourse([FromBody] CoursePostDto coursePostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var course = await _courseRepository.AddCourseAsync(coursePostDto.ToCourse());
            
            if(course == null){
                return BadRequest();
            }

            return Ok(course.ToCourseDto());
        }
        //Since both the Id and the Course Name act as a primary key, there's nothing to be changed.
        /*
        [HttpPut("Course/{Id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCourse(int Id, [FromBody] CourseUpdateDto courseUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _courseRepository.GetCourseAsync(Id);

            if(course == null){
                return NotFound();
            }

            if(course.CourseId != Id){
                return BadRequest();
            }

            course.CourseName = courseUpdateDto.CourseName;
            
            var updatedCourse = await _courseRepository.UpdateCourseAsync(course);
            
            if(updatedCourse == null){
                return BadRequest();
            }

            return Ok(updatedCourse.ToCourseDto());
        }*/
        [HttpDelete("Course/{Name}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCourse(String Name){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _courseRepository.DeleteCourseAsync(Name);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
    }
}