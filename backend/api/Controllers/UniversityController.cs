using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.University;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UniversityController: ControllerBase
    {
        private readonly IUniversityRepository _universityRepo;
        public UniversityController(IUniversityRepository universityRepository){
            _universityRepo = universityRepository;
        }
        [HttpGet("University/{Id:int}")]
        public async Task<IActionResult> GetUniversityById(int Id){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var university = await _universityRepo.GetUniversityByIdAsync(Id);

            if(university == null){
                return BadRequest();
            }

            return Ok(university.ToUniversityDto());
        }
        [HttpPost("University")]
        public async Task<IActionResult> AddUniversity([FromBody] UniversityPostDto universityPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var university = await _universityRepo.CreateUniversityAsync(universityPostDto.ToUniversity());
            
            if(university == null){
                return BadRequest();
            }

            return Ok(university.ToUniversityDto());
        }
        [HttpPut("University/{Id:int}")]
        public async Task<IActionResult> UpdateUniversity(int Id, [FromBody] UniversityUpdateDto universityUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var university = await _universityRepo.GetUniversityByIdAsync(Id);

            if(university == null){
                return BadRequest();
            }

            if(universityUpdateDto.UniversityId != university.UniversityId){
                return BadRequest();
            }

            university.Name = universityUpdateDto.Name;
            university.Address = universityUpdateDto.Address;
            university.Mail = universityUpdateDto.Mail;
            university.PhoneNumber = universityUpdateDto.PhoneNumber;
            university.CurrentSchoolYear = universityUpdateDto.CurrentSchoolYear;
            university.RectorId = universityUpdateDto.RectorId;
            
            var updatedUniversity = await _universityRepo.UpdateUniversityAsync(university);
            
            if(updatedUniversity == null){
                return BadRequest();
            }

            return Ok(updatedUniversity.ToUniversityDto());
        }

        [HttpDelete("University/{Id:int}")]
        public async Task<IActionResult> DeleteUniversity(int Id){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _universityRepo.DeleteUniversityByIdAsync(Id);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }

    }
}