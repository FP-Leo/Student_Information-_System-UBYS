using api.DTO.AccountInfo;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AccountInfoController: ControllerBase
    {
        private readonly IStudentAccountRepository _studentAccRepo;
        private readonly ILecturerAccountRepository _lecturerAccRepo;
        private readonly IAdvisorAccountRepository _advisorAccRepo;
        private readonly IAdministratorAccountRepository _adminAccountRepo;

        public AccountInfoController(IStudentAccountRepository studentAccRepo, ILecturerAccountRepository lecturerAccRepository, IAdvisorAccountRepository advisorAccRepository, IAdministratorAccountRepository administratorAccRepository){
            _studentAccRepo = studentAccRepo;
            _lecturerAccRepo = lecturerAccRepository;
            _advisorAccRepo = advisorAccRepository;
            _adminAccountRepo = administratorAccRepository;
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

        [HttpGet("Student/AccountInfo/UserId/{UID}")]
        public async Task<IActionResult> GetStudentByUID(string UID){
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
        public async Task<IActionResult> GetStudentByTc(string TC){
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
        }
        // Function that will be used for an admin to change data of a student account if the data entered was invalid/outdated.
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
            accInfo.PersonalMail = studentAccountPOSTDto.PersonalMail;
            accInfo.Phone = studentAccountPOSTDto.Phone;

            var result = await _studentAccRepo.UpdateStudentAccountAsync(accInfo);

            if(result == null){
                return StatusCode(500);
            }

            return Ok(result.ToStudentAccountDto());
        }
        // Function that will be used by the student to update its info, the [authorize] will be done later.
        [HttpPut("Student/Update/AccountInfo/")]
        public async Task<IActionResult> UpdateSettingsStudent([FromBody] StudentAccountUpdateDto studentAccountUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(studentAccountUpdateDto.UserId == null)
            {
                return BadRequest(ModelState);
            }

            var accInfo = await _studentAccRepo.GetStudentAccountByUIDAsync(studentAccountUpdateDto.UserId); 

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

        // Lecturer 
        [HttpGet("Lecturer/AccountInfo/UserId/{UID}")]
        public async Task<IActionResult> GetLecturerByUID(string UID){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var accInfo = await _lecturerAccRepo.GetLecturerAccountByUIDAsync(UID);

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToLecturerAccountDto());
        }
        [HttpGet("Lecturer/AccountInfo/TC/{TC}")]
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
        [HttpGet("Lecturer/AccountInfo/SSN/{SSN:int}")]
        public async Task<IActionResult> GetLecturerBySsn(int SSN){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accInfo = await _lecturerAccRepo.GetLecturerAccountBySSNAsync(SSN);

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToLecturerAccountDto());
        }
        // Function that will be used by an admin to change data of the lecturer account if the data entered was invalid/outdated.
        [HttpPut("Admin/Lecturer/Update/AccountInfo/")]
        public async Task<IActionResult> UpdateLecturerAccount([FromBody] LecturerAccountPOSTDto lecturerAccountPOSTDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(lecturerAccountPOSTDto.UserId == null)
                return BadRequest(ModelState);
            
            var accInfo = await _lecturerAccRepo.GetLecturerAccountByUIDAsync(lecturerAccountPOSTDto.UserId); 

            if(accInfo == null){
                return NotFound();
            }

            accInfo.FirstName = lecturerAccountPOSTDto.FirstName;
            accInfo.LastName = lecturerAccountPOSTDto.LastName;
            accInfo.BirthDate = lecturerAccountPOSTDto.BirthDate;
            accInfo.LecturerId = lecturerAccountPOSTDto.LecturerId;
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
        // Function that will be used by the lecturer to update its info, the [authorize] will be done later.
        [HttpPut("Lecturer/Update/AccountInfo/")]
        public async Task<IActionResult> UpdateSettingsLecturer([FromBody] LecturerAccountUpdateDto lecturerAccountPOSTDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(lecturerAccountPOSTDto.UserId == null)
            {
                return BadRequest(ModelState);
            }

            var accInfo = await _lecturerAccRepo.GetLecturerAccountByUIDAsync(lecturerAccountPOSTDto.UserId);

            if(accInfo == null){
                return NotFound();
            }

            accInfo.Phone = lecturerAccountPOSTDto.Phone;
            accInfo.PersonalMail = lecturerAccountPOSTDto.PersonalMail;

            var result = await _lecturerAccRepo.UpdateLecturerAccountAsync(accInfo);

            if(result == null){
                return StatusCode(500);
            }

            return Ok(result.ToLecturerAccountDto());
        }

    }
}