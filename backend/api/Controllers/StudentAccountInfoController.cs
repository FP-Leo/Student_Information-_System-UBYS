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
    public class StudentAccountInfoController: ControllerBase
    {
        private readonly IStudentAccountRepository _studentAccRepo;
        public StudentAccountInfoController(IStudentAccountRepository studentAccountRepository){
            _studentAccRepo = studentAccountRepository;
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

        [HttpGet("User/Student/Account/Details")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetStudentData(){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            var accInfo = await _studentAccRepo.GetStudentAccountByTCAsync(TC); 

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToStudentAccountDto());
        }
        // Function that will be used by the student to update its info, the [authorize] will be done later.
        [HttpPut("User/Student/Account/Details")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> UpdateSettingsStudent([FromBody] StudentAccountUpdateDto studentAccountUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            var accInfo = await _studentAccRepo.GetStudentAccountByTCAsync(TC); 

            if(accInfo == null){
                return NotFound();
            }

            accInfo.Phone = studentAccountUpdateDto.Phone;
            accInfo.PersonalMail =studentAccountUpdateDto.PersonalMail;

           var result = await _studentAccRepo.UpdateStudentAccountAsync(accInfo);

            if(result == null){
                return StatusCode(500);
            }

            return Ok(result.ToStudentAccountDto());
        }
        // Function that will be used for an admin to get data of a student account.
        [HttpGet("Admin/Student/Account/Details/{TC}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetStudentByTC(string TC){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(InvalidTC(TC))
            {
                return BadRequest(ModelState);
            }

            var accInfo = await _studentAccRepo.GetStudentAccountByTCAsync(TC); 

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToStudentAccountDto());
        }
        /*
        [HttpGet("Student/AccountInfo/SSN/{SSN:int}")]
        public async Task<IActionResult> GetStudentBySsn(int SSN){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accInfo = await _studentAccRepo.GetStudentAccountBySSNAsync(SSN); 

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToStudentAccountDto());
        }*/
        // Function that will be used for an admin to change data of a student account if the data entered was invalid/outdated.
        [HttpPut("Admin/Student/Account/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStudentAccount([FromBody] StudentAccountPOSTDto studentAccountPOSTDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(studentAccountPOSTDto.TC == null){
                return BadRequest(ModelState);
            }
            
            var accInfo = await _studentAccRepo.GetStudentAccountByTCAsync(studentAccountPOSTDto.TC); 

            if(accInfo == null){
                return NotFound();
            }

            if(studentAccountPOSTDto.CurrentType != "Bachelor" && studentAccountPOSTDto.CurrentType != "Master" && studentAccountPOSTDto.CurrentType != "Doctoral" && studentAccountPOSTDto.CurrentType != "Associate"){
                return BadRequest("Bad input on the student type.");
            }

            if(studentAccountPOSTDto.CurrentStatus != "Active" && studentAccountPOSTDto.CurrentStatus != "Frozen"){
                return BadRequest("Bad input on the student status.");
            }

            accInfo.FirstName = studentAccountPOSTDto.FirstName;
            accInfo.LastName = studentAccountPOSTDto.LastName;
            accInfo.BirthDate = studentAccountPOSTDto.BirthDate;
            accInfo.SSN = studentAccountPOSTDto.SSN;
            accInfo.CurrentType = studentAccountPOSTDto.CurrentType;
            accInfo.CurrentStatus = studentAccountPOSTDto.CurrentStatus;
            accInfo.SchoolMail = studentAccountPOSTDto.SchoolMail;
            accInfo.PersonalMail = studentAccountPOSTDto.PersonalMail;
            accInfo.Phone = studentAccountPOSTDto.Phone;

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