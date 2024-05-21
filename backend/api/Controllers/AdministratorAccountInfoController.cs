using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using api.DTO.AccountInfo;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AdministratorAccountInfoController: ControllerBase
    {
        private readonly IAdministratorAccountRepository _adminAccRepo;
        public AdministratorAccountInfoController(IAdministratorAccountRepository administratorAccRepository){
            _adminAccRepo = administratorAccRepository;
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
        // Administrator 
        [HttpGet("Administrator/AccountInfo/")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetAdministratorData(){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            var accInfo = await _adminAccRepo.GetAdministratorAccountByTCAsync(TC);

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToAdministratorAccountDto());
        }
        // Function that will be used by the administrator to update its info, the [authorize] will be done later.
        [HttpPut("Administrator/AccountInfo/Update")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateSettingsAdministrator([FromBody] AdministratorAccountUpdateDto administratorAccountPOSTDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            var accInfo = await _adminAccRepo.GetAdministratorAccountByTCAsync(TC);

            if(accInfo == null){
                return NotFound();
            }

            accInfo.Phone = administratorAccountPOSTDto.Phone;
            accInfo.PersonalMail = administratorAccountPOSTDto.PersonalMail;

            var result = await _adminAccRepo.UpdateAdministratorAccountAsync(accInfo);

            if(result == null){
                return StatusCode(500);
            }

            return Ok(result.ToAdministratorAccountDto());
        }
        // Function that will be used by an admin to get data of an Administrator account.
        [HttpGet("Admin/Administrator/AccountInfo/{TC}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAdministratorByTc(string TC){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(InvalidTC(TC))
            {
                return BadRequest(ModelState);
            }

            var accInfo = await _adminAccRepo.GetAdministratorAccountByTCAsync(TC);

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToAdministratorAccountDto());
        }
        /*
        [HttpGet("Administrator/AccountInfo/SSN/{SSN:int}")]
        public async Task<IActionResult> GetAdministratorBySsn(int SSN){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accInfo = await _adminAccRepo.GetAdministratorAccountBySSNAsync(SSN);

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToAdministratorAccountDto());
        }
        */
        // Function that will be used by an admin to change data of the Administrator account if the data entered was invalid/outdated.
        [HttpPut("Admin/Administrator/AccountInfo/Update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAdministratorAccount([FromBody] AdministratorAccountPOSTDto administratorAccountPOSTDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(administratorAccountPOSTDto.TC == null)
                return BadRequest(ModelState);
            
            var accInfo = await _adminAccRepo.GetAdministratorAccountByTCAsync(administratorAccountPOSTDto.TC); 

            if(accInfo == null){
                return NotFound();
            }

            accInfo.FirstName = administratorAccountPOSTDto.FirstName;
            accInfo.LastName = administratorAccountPOSTDto.LastName;
            accInfo.BirthDate = administratorAccountPOSTDto.BirthDate;
            accInfo.AdministratorId = administratorAccountPOSTDto.AdministratorId;
            accInfo.SchoolMail = administratorAccountPOSTDto.SchoolMail;
            accInfo.PersonalMail = administratorAccountPOSTDto.PersonalMail;
            accInfo.Phone = administratorAccountPOSTDto.Phone;

            var result = await _adminAccRepo.UpdateAdministratorAccountAsync(accInfo);

            if(result == null){
                return StatusCode(500);
            }

            return Ok(result.ToAdministratorAccountDto());
        }
    }
}