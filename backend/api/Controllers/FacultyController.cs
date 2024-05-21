using api.DTO.Faculty;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyRepository _facultyRepository;
        public FacultyController(IFacultyRepository facultyRepository){
            _facultyRepository = facultyRepository;
        }
        [HttpGet("Faculty/{Id:int}")]
        public async Task<IActionResult> GetFacultyById(int Id){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var faculty = await _facultyRepository.GetFacultyByIdAsync(Id);

            if(faculty == null){
                return BadRequest();
            }

            return Ok(faculty.ToFacultyDto());
        }
        [HttpPost("Faculty")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddFaculty([FromBody] FacultyPostDto facultyPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var faculty = await _facultyRepository.CreateFacultyAsync(facultyPostDto.ToFaculty());
            
            if(faculty == null){
                return BadRequest();
            }

            return Ok(faculty.ToFacultyDto());
        }
        [HttpPut("Faculty/{Id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateFaculty(int Id, [FromBody] FacultyUpdateDto facultyUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var faculty = await _facultyRepository.GetFacultyByIdAsync(Id);

            if(faculty == null){
                return BadRequest();
            }

            if(facultyUpdateDto.FacultyID != faculty.FacultyID){
                return BadRequest();
            }

            faculty.Address = facultyUpdateDto.Address;
            faculty.WebSite = facultyUpdateDto.WebSite;
            faculty.Mail = facultyUpdateDto.Mail;
            faculty.PhoneNumber = facultyUpdateDto.PhoneNumber;
            faculty.DeanTC = facultyUpdateDto.DeanTC;
            
            var updatedFaculty = await _facultyRepository.UpdateFacultyAsync(faculty);
            
            if(updatedFaculty == null){
                return BadRequest();
            }

            return Ok(updatedFaculty.ToFacultyDto());
        }
        [HttpDelete("Faculty/{Id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteFaculty(int Id){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _facultyRepository.DeleteFacultyByIdAsync(Id);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
    }
}