using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.Faculty;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.MappingProfiles;

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
        [HttpGet("University/Faculty/")]
        public async Task<IActionResult> GetFaculty([FromQuery] String UniName, [FromQuery] String FacultyName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var faculty = await _facultyRepository.GetUniFacultyAsync(UniName, FacultyName);

            if(faculty == null){
                return BadRequest();
            }

            return Ok(faculty.ToFacultyDto());
        }
        [HttpGet("University/Faculties/")]
        public async Task<IActionResult> GetFaculties([FromQuery] String UniName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var faculties = await _facultyRepository.GetUniFacultiesAsync(UniName);

            if(faculties == null){
                return BadRequest();
            }

            return Ok(faculties);
        }
        [HttpPost("University/Faculty")]
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
        [HttpPut("University/Faculty/")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateFaculty([FromQuery] String UniName, [FromQuery] String FacultyName, [FromBody] FacultyUpdateDto facultyUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var faculty = await _facultyRepository.GetUniFacultyAsync(UniName, FacultyName);

            if(faculty == null){
                return BadRequest();
            }

            if(facultyUpdateDto.UniName != faculty.UniName || facultyUpdateDto.FacultyName != faculty.FacultyName){
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
        [HttpDelete("University/Faculty/")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteFaculty([FromQuery] String UniName, [FromQuery] String FacultyName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _facultyRepository.DeleteUniFacultyAsync(UniName, FacultyName);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
    }
}