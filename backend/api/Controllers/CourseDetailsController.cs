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
        private readonly ICourseRepository _courseRepo;
        public CourseDetailsController(ICourseDetailsRepository courseExplanationRepository, ICourseRepository courseRepository){
            _courseDetailsRepo = courseExplanationRepository;
            _courseRepo = courseRepository;
        }
        [HttpGet("University/Faculty/Department/Course/Details")]
        public async Task<IActionResult> GetCourseDetails([FromQuery] int CourseDetailsId){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var courseDetails = await _courseDetailsRepo.GetCourseDetailsAsync(CourseDetailsId);

            if(courseDetails == null){
                return NotFound();
            }

            return Ok(courseDetails.ToCourseExplanationDto());
        }
        [HttpPost("University/Faculty/Department/Course/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCourseDetails([FromBody] CourseDetailsPostDto courseDetailsPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var course = await _courseRepo.GetCourseAsync(courseDetailsPostDto.CourseName);
            if(course == null)
                return NotFound();

            if(courseDetailsPostDto.CourseType != "Mandatory" && courseDetailsPostDto.CourseType != "Optional"){
                return BadRequest("Bad input on the course type.");
            }

            if(courseDetailsPostDto.CourseLanguage != "English" && courseDetailsPostDto.CourseLanguage != "Turkish"){
                return BadRequest("Bad input on the course type.");
            }

            var courseDetails = await _courseDetailsRepo.AddCourseDetailsAsync(courseDetailsPostDto.ToCourseExplanation());

            if(courseDetails == null)
                return StatusCode(500);

            return Ok(courseDetails.ToCourseExplanationDto());
        }
        [HttpPut("University/Faculty/Department/Course/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCourseDetails([FromQuery] int CourseDetailsId, [FromBody] CourseDetailsUpdateDto courseDetailsUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseDetails = await _courseDetailsRepo.GetCourseDetailsAsync(CourseDetailsId);
            
            if(courseDetails == null){
                return NotFound();
            }

            if(courseDetails.Id != courseDetailsUpdateDto.CourseDetailsId){
                return BadRequest();
            }

            courseDetails.CourseLanguage = courseDetailsUpdateDto.CourseLanguage;
            courseDetails.CourseLevel = courseDetailsUpdateDto.CourseLevel;
            courseDetails.CourseType = courseDetailsUpdateDto.CourseType;
            courseDetails.CourseContent = courseDetailsUpdateDto.CourseContent;
            
            var updatedCourseDetails = await _courseDetailsRepo.UpdateCourseDetailsAsync(courseDetails);
            
            if(updatedCourseDetails == null){
                return StatusCode(500);
            }

            return Ok(updatedCourseDetails.ToCourseExplanationDto());
        }
        [HttpDelete("University/Faculty/Department/Course/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCourseDetails([FromQuery] int CourseDetailsId){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _courseDetailsRepo.DeleteCourseDetailsAsync(CourseDetailsId);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
    }
}