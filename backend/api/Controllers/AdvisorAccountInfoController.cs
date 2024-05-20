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
    public class AdvisorAccountInfoController: ControllerBase
    {
        private readonly IAdvisorAccountRepository _advisorAccRepo;

        public AdvisorAccountInfoController(IAdvisorAccountRepository advisorAccountRepository){
            _advisorAccRepo = advisorAccountRepository;
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
        
        //Advisor 
        [HttpGet("Advisor/AccountInfo/UserId/")]
        [Authorize(Roles = "Advisor")]
        public async Task<IActionResult> GetAdvisorByUID(){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId =  User.FindFirstValue(ClaimTypes.NameIdentifier);

            var accInfo = await _advisorAccRepo.GetAdvisorAccountByUIDAsync(userId);

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToAdvisorAccountDto());
        }
        [HttpGet("Advisor/AccountInfo/TC/{TC}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAdvisorByTc(string TC){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(InvalidTC(TC))
            {
                return BadRequest(ModelState);
            }

            var accInfo = await _advisorAccRepo.GetAdvisorAccountByTCAsync(TC);

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToAdvisorAccountDto());
        }
        /*
        [HttpGet("Advisor/AccountInfo/SSN/{SSN:int}")]
        public async Task<IActionResult> GetAdvisorBySsn(int SSN){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accInfo = await _advisorAccRepo.GetAdvisorAccountBySSNAsync(SSN);

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToAdvisorAccountDto());
        }
        */
        // Function that will be used by an admin to change data of the Advisor account if the data entered was invalid/outdated.
        [HttpPut("Admin/Advisor/Update/AccountInfo/")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAdvisorAccount([FromBody] AdvisorAccountPOSTDto advisorAccountPOSTDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(advisorAccountPOSTDto.UserId == null)
                return BadRequest(ModelState);
            
            var accInfo = await _advisorAccRepo.GetAdvisorAccountByUIDAsync(advisorAccountPOSTDto.UserId); 

            if(accInfo == null){
                return NotFound();
            }

            accInfo.FirstName = advisorAccountPOSTDto.FirstName;
            accInfo.LastName = advisorAccountPOSTDto.LastName;
            accInfo.BirthDate = advisorAccountPOSTDto.BirthDate;
            accInfo.AdvisorSSN = advisorAccountPOSTDto.AdvisorId;
            accInfo.SchoolMail = advisorAccountPOSTDto.SchoolMail;
            accInfo.PersonalMail = advisorAccountPOSTDto.PersonalMail;
            accInfo.Phone = advisorAccountPOSTDto.Phone;

            var result = await _advisorAccRepo.UpdateAdvisorAccountAsync(accInfo);

            if(result == null){
                return StatusCode(500);
            }

            return Ok(result.ToAdvisorAccountDto());
        }
        // Function that will be used by the advisor to update its info, the [authorize] will be done later.
        [HttpPut("Advisor/Update/AccountInfo/")]
        [Authorize(Roles = "Advisor")]
        public async Task<IActionResult> UpdateSettingsAdvisor([FromBody] AdvisorAccountUpdateDto advisorAccountPOSTDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId =  User.FindFirstValue(ClaimTypes.NameIdentifier);

            var accInfo = await _advisorAccRepo.GetAdvisorAccountByUIDAsync(userId);

            if(accInfo == null){
                return NotFound();
            }

            accInfo.Phone = advisorAccountPOSTDto.Phone;
            accInfo.PersonalMail = advisorAccountPOSTDto.PersonalMail;

            var result = await _advisorAccRepo.UpdateAdvisorAccountAsync(accInfo);

            if(result == null){
                return StatusCode(500);
            }

            return Ok(result.ToAdvisorAccountDto());
        }

    }
}