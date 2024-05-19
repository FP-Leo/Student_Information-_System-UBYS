using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.AccountInfo;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AccountInfoController: ControllerBase
    {
        private readonly IStudentAccountRepository _studentAccRepo;

        public AccountInfoController(IStudentAccountRepository studentAccRepo){
            _studentAccRepo = studentAccRepo;
        }

        [HttpGet("Student/AccountInfo/UserId/{UID}")]
        public async Task<IActionResult> GetByUID(string UID){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var accInfo = await _studentAccRepo.GetStudentAccountByUIDAsync(UID); 

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToStudentAccountDto());
        }

        [HttpGet("Student/AccountInfo/TC/{TC}")]
        public async Task<IActionResult> GetByTc(string TC){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(TC.Length != 11)
            {
                return BadRequest("TC must be 11 characters long.");
            }

            foreach(char c in TC){
                if(!System.Char.IsDigit(c)){
                    return BadRequest("TC can only contain integers.");
                }
            }

            var accInfo = await _studentAccRepo.GetStudentAccountByTCAsync(TC); 

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToStudentAccountDto());
        }
        
        [HttpGet("Student/AccountInfo/SSN/{SSN:int}")]
        public async Task<IActionResult> GetBySsn(int SSN){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accInfo = await _studentAccRepo.GetStudentAccountBySSNAsync(SSN); 

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToStudentAccountDto());
        }
        // Function that will be used for an admin to change data of an account if the data entered was invalid/outdated.
        [HttpPut("Admin/Student/Update/AccountInfo/")]
        public async Task<IActionResult> UpdateStudentAccount([FromBody] StudentAccountPOSTDto studentAccountPOSTDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var accInfo = await _studentAccRepo.GetStudentAccountByUIDAsync(studentAccountPOSTDto.UserId); 

            if(accInfo == null){
                return NotFound();
            }

            accInfo.FirstName = studentAccountPOSTDto.FirstName;
            accInfo.LastName = studentAccountPOSTDto.LastName;
            accInfo.BirthDate = studentAccountPOSTDto.BirthDate;
            accInfo.SSN = studentAccountPOSTDto.SSN;
            accInfo.CurrentType = studentAccountPOSTDto.CurrentType;
            accInfo.CurrentStatus = studentAccountPOSTDto.CurrentStatus;
            accInfo.SchoolMail = studentAccountPOSTDto.SchoolMail;
            accInfo.Phone = studentAccountPOSTDto.Phone;

            var result = await _studentAccRepo.UpdateStudentAccountAsync(accInfo);

            if(result == null){
                return StatusCode(500);
            }

            return Ok(result.ToStudentAccountDto());
        }
        //Function that will be used by the user to update its info, the [authorize] will be done later.
        [HttpPut("Student/Update/AccountInfo/")]
        public async Task<IActionResult> UpdateSettingsStudent([FromBody] StudentAccountUpdateDto studentAccountUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var accInfo = await _studentAccRepo.GetStudentAccountByUIDAsync(studentAccountUpdateDto.UserId); 

            if(accInfo == null){
                return NotFound();
            }

            accInfo.Phone = studentAccountUpdateDto.Phone;

           var result = await _studentAccRepo.UpdateStudentAccountAsync(accInfo);

            if(result == null){
                return StatusCode(500);
            }

            return Ok(result.ToStudentAccountDto());
        }

        //Code tested, works as intended.
        //Not going to be used for security reasons, the account info will only get created when the account is created.
        /*
        [HttpPost("Student/New/AccountInfo")]
        public async Task<IActionResult> CreateStudentAccountInfo([FromBody] StudentAccountPOSTDto studentAccPModel){
            var studentAcc = studentAccPModel.POSTToStudentAccount();

            var result = await _studentAccRepo.CreateStudentAccountAsync(studentAcc);

            if(result == null){
                return StatusCode(500);
            }

            return CreatedAtAction(nameof(GetBySsn), new { SSN = studentAcc.SSN }, studentAcc.ToStudentAccountDto());
        }
        */
        //Code tested, works as intended.
        //Not going to be used for security reasons, the account info will only get deleted when the account is deleted.
        /*
        [HttpDelete]
        [Route("Student/Account/Delete/{TC}")]
        public async Task<IActionResult> DeleteStudentAccountInfo([FromRoute] string TC){
            var accInfo = await _studentAccRepo.GetStudentAccountByTCAsync(TC);

            if(accInfo == null){
                return NotFound();
            }

            var deleted = await _studentAccRepo.DeleteStudentAccountAsync(accInfo);

            if(deleted == null){
                return StatusCode(500, "Failed to delete the student account.");
            }

            return NoContent();
        }
        */
    }
}