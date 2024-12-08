using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.AccountInfo.Lecturer;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.MappingProfiles;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LecturerAccountInfoController: ControllerBase
    {
        private readonly ILecturerAccountRepository _lecturerAccRepo;
        public LecturerAccountInfoController(ILecturerAccountRepository lecturerAccountRepository){
            _lecturerAccRepo = lecturerAccountRepository;
        }
        private bool InvalidTC(string TC){
            if( TC == null || TC.Length != 11)
                return true;

            foreach(char c in TC){
                if(!System.Char.IsDigit(c))
                    return true;
            }

            return false;
        }
        
        // Lecturer 
        [HttpGet("User/Lecturer/Account/Details")]
        [Authorize(Roles = "Lecturer")]
        public async Task<IActionResult> GetLecturerData(){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            var accInfo = await _lecturerAccRepo.GetLecturerAccountByTCAsync(TC);

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToLecturerAccountDto());
        }
        // Function that will be used by the lecturer to update its info, the [authorize] will be done later.
        [HttpPut("User/Lecturer/Account/Details")]
        [Authorize(Roles = "Lecturer")]
        public async Task<IActionResult> UpdateSettingsLecturer([FromBody] LecturerAccountUpdateDto lecturerAccountUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            var accInfo = await _lecturerAccRepo.GetLecturerAccountByTCAsync(TC);

            if(accInfo == null){
                return NotFound();
            }

            accInfo.Phone = lecturerAccountUpdateDto.Phone;
            accInfo.PersonalMail = lecturerAccountUpdateDto.PersonalMail;

            var result = await _lecturerAccRepo.UpdateLecturerAccountAsync(accInfo);

            if(result == null){
                return StatusCode(500);
            }

            return Ok(result.ToLecturerAccountDto());
        } 
        // Function that will be used by an admin to get data of a lecturer account.
        [HttpGet("Admin/Lecturer/Account/Details/{TC}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetLecturerByTc(string TC){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(InvalidTC(TC))
            {
                return BadRequest(ModelState);
            }

            var accInfo = await _lecturerAccRepo.GetLecturerAccountByTCAsync(TC);

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToLecturerAccountDto());
        }
        /*
        [HttpGet("Lecturer/AccountInfo/ID/{ID:int}")]
        public async Task<IActionResult> GetLecturerByID(int ID){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accInfo = await _lecturerAccRepo.GetLecturerAccountByIDAsync(ID);

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToLecturerAccountDto());
        }*/
        // Function that will be used by an admin to change data of the lecturer account if the data entered was invalid/outdated.
        [HttpPut("Admin/Lecturer/Account/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateLecturerAccount([FromBody] LecturerAccountPOSTDto lecturerAccountPOSTDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(lecturerAccountPOSTDto.TC == null)
                return BadRequest(ModelState);
            
            var accInfo = await _lecturerAccRepo.GetLecturerAccountByTCAsync(lecturerAccountPOSTDto.TC); 

            if(accInfo == null){
                return NotFound();
            }

            accInfo.FirstName = lecturerAccountPOSTDto.FirstName;
            accInfo.LastName = lecturerAccountPOSTDto.LastName;
            accInfo.BirthDate = lecturerAccountPOSTDto.BirthDate;
            accInfo.ID = lecturerAccountPOSTDto.LecturerId;
            accInfo.CurrentStatus = lecturerAccountPOSTDto.CurrentStatus;
            accInfo.Title = lecturerAccountPOSTDto.Title;
            accInfo.TotalWorkHours = lecturerAccountPOSTDto.TotalWorkHours;
            accInfo.SchoolMail = lecturerAccountPOSTDto.SchoolMail;
            accInfo.PersonalMail = lecturerAccountPOSTDto.PersonalMail;
            accInfo.Phone = lecturerAccountPOSTDto.Phone;

            var result = await _lecturerAccRepo.UpdateLecturerAccountAsync(accInfo);

            if(result == null){
                return StatusCode(500);
            }

            return Ok(result.ToLecturerAccountDto());
        }
    }
}