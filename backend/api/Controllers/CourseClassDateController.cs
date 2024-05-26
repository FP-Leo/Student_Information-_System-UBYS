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
        public CourseClassDateController(ICourseClassDateRepository courseClassDateRepository){
            _courseClassDateRepo = courseClassDateRepository;
        }
        [HttpGet("CourseClassDate/{Id:int}")]
        public async Task<IActionResult> GetCourseClassDateById(int Id){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var courseClassDate = await _courseClassDateRepo.GetCourseClassDateByIdAsync(Id);

            if(courseClassDate == null){
                return BadRequest();
            }

            return Ok(courseClassDate.ToCourseClassDateDto());
        }
        [HttpPost("CourseClassDate")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCourseClassDate([FromBody] CourseClassDatePostDto courseClassDatePostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var courseClassDate = await _courseClassDateRepo.CreateCourseClassDateAsync(courseClassDatePostDto.ToCourseClassDate());
            
            if(courseClassDate == null){
                return BadRequest();
            }

            return Ok(courseClassDate.ToCourseClassDateDto());
        }
        [HttpPut("CourseClassDate/{Id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCourseClassDate(int Id, [FromBody] CourseClassDateUpdateDto courseClassDateUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseClassDate = await _courseClassDateRepo.GetCourseClassDateByIdAsync(Id);

            if(courseClassDate == null){
                return BadRequest();
            }

            if(courseClassDateUpdateDto.Id != courseClassDate.Id){
                return BadRequest();
            }

            courseClassDate.Id = courseClassDateUpdateDto.Id;
            courseClassDate.DepartmentName = courseClassDate.DepartmentName;
            courseClassDate.CourseName = courseClassDate.CourseName;
            courseClassDate.SchoolYear = courseClassDate.SchoolYear;
            courseClassDate.Day = courseClassDateUpdateDto.Day;
            courseClassDate.Time = courseClassDateUpdateDto.Time;
            courseClassDate.NumberOfClasses = courseClassDateUpdateDto.NumberOfClasses;
        
            var updatedCourseClassDate = await _courseClassDateRepo.UpdateCourseClassDateAsync(courseClassDate);
            
            if(updatedCourseClassDate == null){
                return BadRequest();
            }

            return Ok(updatedCourseClassDate.ToCourseClassDateDto());
        }

        [HttpDelete("CourseClassDate/{Id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCourseClassDate(int Id){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _courseClassDateRepo.DeleteCourseClassDateByIdAsync(Id);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }

    }
}