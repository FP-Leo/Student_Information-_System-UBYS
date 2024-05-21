using api.DTO.CourseDetails;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CourseDetailsController : ControllerBase
    {
        private readonly ICourseDetailsRepository _courseDetailsRepo;
        private readonly IDepartmentCourseRepository _depCourseRepo;
        public CourseDetailsController(ICourseDetailsRepository courseExplanationRepository, IDepartmentCourseRepository departmentCourseRepository){
            _courseDetailsRepo = courseExplanationRepository;
            _depCourseRepo = departmentCourseRepository;
        }
        [HttpGet("Department/Course/Details")]
        public async Task<IActionResult> GetCourseDetails([FromQuery] String DepName, [FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var courseDetails = await _courseDetailsRepo.GetCourseDetailsAsync(DepName,CourseName);

            if(courseDetails == null){
                return NotFound();
            }

            return Ok(courseDetails.ToCourseExplanationDto());
        }
        [HttpPost("Department/Course/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCourseDetails([FromBody] CourseDetailsPostDto courseDetailsPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var depCourse = await _depCourseRepo.CourseDetailsByCourseAndDepNameAsync(courseDetailsPostDto.CourseName, courseDetailsPostDto.DepartmentName);
            
            if(depCourse == null){
                return NotFound();
            }

            var depCourseExplanation = await _courseDetailsRepo.AddCourseDetailsAsync(courseDetailsPostDto.ToCourseExplanation());

            if(depCourseExplanation == null){
                return StatusCode(500);
            }

            return Ok(depCourseExplanation.ToCourseExplanationDto());
        }
        [HttpPut("Department/Course/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCourseDetails([FromQuery] String DepName, [FromQuery] String CourseName, [FromBody] CourseDetailsUpdateDto courseDetailsUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseDetails = await _courseDetailsRepo.GetCourseDetailsAsync(DepName, CourseName);
            
            if(courseDetails == null){
                return NotFound();
            }

            if(DepName != courseDetailsUpdateDto.DepartmentName || CourseName != courseDetailsUpdateDto.CourseName){
                return BadRequest();
            }

            courseDetails.CourseName = courseDetailsUpdateDto.CourseName;
            courseDetails.CourseLevel = courseDetailsUpdateDto.CourseLevel;
            courseDetails.CourseType = courseDetailsUpdateDto.CourseType;
            courseDetails.CourseContent = courseDetailsUpdateDto.CourseContent;
            
            var updatedCourseExplanation = await _courseDetailsRepo.UpdateCourseDetailsAsync(courseDetails);
            
            if(updatedCourseExplanation == null){
                return StatusCode(500);
            }

            return Ok(updatedCourseExplanation.ToCourseExplanationDto());
        }
        [HttpDelete("Department/Course/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCourseDetails([FromQuery] String DepName, [FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _courseDetailsRepo.DeleteCourseDetailsAsync(DepName, CourseName);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
    }
}