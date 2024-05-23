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
        [HttpGet("Student/Departments/Details")]
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
        [HttpGet("Student/Department/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetDepDetailByTcAndDepId([FromQuery] String TC, [FromQuery] int DepId){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var studentDepDetails = await _studentDepDetailsRepository.GetStudentDepDetailByTcAndDepIdAsync(TC, DepId);

            if(studentDepDetails == null){
                return NotFound();
            }

            return Ok(studentDepDetails.ToStudentDepDetailsDto());
        }
        [HttpPost("Student/Departmant/Details")]
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

            var validDep = await _depRepository.GetDepartmentByIdAsync(studentDepDetailsPostDto.DepartmentId);

            if(validDep == null){
                return BadRequest("Department doesn't exist");
            }
            
            var depsDetails = await _studentDepDetailsRepository.CreateStudentDepDetailAsync(studentDepDetailsPostDto.ToStudentDepDetails());
            
            if(depsDetails == null){
                return BadRequest();
            }

            return Ok(depsDetails.ToStudentDepDetailsDto());
        }
        [HttpPut("Student/Departmant/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStudentDepDetails([FromQuery] String TC, [FromQuery] int DepId, [FromBody] StudentDepDetailsUpdateDto studentDepDetailsUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentDepDetails = await _studentDepDetailsRepository.GetStudentDepDetailByTcAndDepIdAsync(TC, DepId);

            if(studentDepDetails == null){
                return NotFound();
            }

            if(studentDepDetails.TC != TC && studentDepDetails.DepartmentId != DepId){
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
        [HttpDelete("Student/Department/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStudentDepDetails([FromQuery] String TC, [FromQuery] int DepId){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _studentDepDetailsRepository.DeleteStudentDepDetailAsync(TC, DepId);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
    }
}