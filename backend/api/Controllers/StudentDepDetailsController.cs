using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using api.DTO.StudentDepDetails;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class StudentDepDetailsController: ControllerBase
    {
        private readonly IStudentDepDetailsRepository _studentDepDetailsRepository;
        private readonly IStudentAccountRepository _studentAccountRepository;
        private readonly IDepartmentRepository _depRepository;

        public StudentDepDetailsController(IStudentDepDetailsRepository studentDepDetailsRepository, IStudentAccountRepository studentAccountRepository, IDepartmentRepository departmentRepository){
            _studentDepDetailsRepository = studentDepDetailsRepository;
            _studentAccountRepository = studentAccountRepository;
            _depRepository = departmentRepository;
        }
        [HttpGet("University/Faculty/Departments/Student/Details")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetStudentDepsDetails(){
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);
            
            var depsDetails = await _studentDepDetailsRepository.GetStudentDepDetailsByTCAsync(TC);
            
            return Ok(depsDetails);
        }
        [HttpGet("University/Faculty/Department/Students/Details")]
        public async Task<IActionResult> GetDepsStudents([FromQuery] String DepName){
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var depsStudents = await _studentDepDetailsRepository.GetDepartmentsStudentsAsync(DepName);
            
            return Ok(depsStudents);
        }
        [HttpGet("University/Faculty/Department/Student/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetDepDetailByTcAndDepId([FromQuery] String TC, [FromQuery] String DepName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var studentDepDetails = await _studentDepDetailsRepository.GetStudentDepDetailAsync(TC, DepName);

            if(studentDepDetails == null){
                return NotFound();
            }

            return Ok(studentDepDetails.ToStudentDepDetailsDto());
        }
        [HttpPost("University/Faculty/Department/Student/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddStudentDepDetail([FromBody] StudentDepDetailsPostDto studentDepDetailsPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validStudent = await _studentAccountRepository.GetStudentAccountByTCAsync(studentDepDetailsPostDto.TC);

            if(validStudent == null){
                return BadRequest("Student doesn't exist");
            }

            var validDep = await _depRepository.GetDepartmentAsync(studentDepDetailsPostDto.DepartmentName);

            if(validDep == null){
                return BadRequest("Department doesn't exist");
            }

            if(studentDepDetailsPostDto.StudentType != "Bachelor" && studentDepDetailsPostDto.StudentType != "Master" && studentDepDetailsPostDto.StudentType != "Doctoral" && studentDepDetailsPostDto.StudentType != "Associate"){
                return BadRequest("Bad input on the student type.");
            }

            if(studentDepDetailsPostDto.StudentStatus != "Graduate" && studentDepDetailsPostDto.StudentStatus != "Active" && studentDepDetailsPostDto.StudentStatus != "Frozen"){
                return BadRequest("Bad input on the student status.");
            }
            
            var depsDetails = await _studentDepDetailsRepository.CreateStudentDepDetailAsync(studentDepDetailsPostDto.ToStudentDepDetails());
            
            if(depsDetails == null){
                return BadRequest();
            }

            return Ok(depsDetails.ToStudentDepDetailsDto());
        }
        [HttpPut("University/Faculty/Department/Student/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStudentDepDetails([FromQuery] String TC, [FromQuery] String DepName, [FromBody] StudentDepDetailsUpdateDto studentDepDetailsUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentDepDetails = await _studentDepDetailsRepository.GetStudentDepDetailAsync(TC, DepName);

            if(studentDepDetails == null){
                return NotFound();
            }

            if(studentDepDetails.TC != TC && studentDepDetails.DepartmentName != DepName){
                return BadRequest();
            }

            studentDepDetails.StudentType = studentDepDetailsUpdateDto.StudentType;
            studentDepDetails.StudentStatus = studentDepDetailsUpdateDto.StudentStatus;
            studentDepDetails.CurrentSchoolYear = studentDepDetailsUpdateDto.CurrentSchoolYear;
            studentDepDetails.CurrentAKTS = studentDepDetailsUpdateDto.CurrentAKTS;
            studentDepDetails.TotalAKTS = studentDepDetailsUpdateDto.TotalAKTS;
            studentDepDetails.Gno = studentDepDetailsUpdateDto.Gno;
            
            var updatedStudentDepDetails = await _studentDepDetailsRepository.UpdateStudentDepDetailAsync(studentDepDetails);
            
            if(updatedStudentDepDetails == null){
                return BadRequest();
            }

            return Ok(updatedStudentDepDetails.ToStudentDepDetailsDto());
        }
        [HttpDelete("University/Faculty/Departments/Student/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStudentDepDetails([FromQuery] String TC, [FromQuery] String DepName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _studentDepDetailsRepository.DeleteStudentDepDetailAsync(TC, DepName);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
        [HttpGet("University/Faculty/Department/Student/Details")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetStudentDocument([FromQuery] String TC, [FromQuery] String DepName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var studentDepDetails = await _studentDepDetailsRepository.GetStudentDepDetailAsync(TC, DepName);

            if(studentDepDetails == null){
                return NotFound();
            }

            return Ok(studentDepDetails.ToStudentDepDetailsDto());
        }
    }
}