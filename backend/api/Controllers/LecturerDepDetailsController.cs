using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using api.DTO.LecturerDepDetails;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LecturerDepDetailsController: ControllerBase
    {
        private readonly ILecturerDepDetailsRepository _lecturerDepDetailsRepository;
        private readonly ILecturerAccountRepository _lecturerAccountRepository;
        private readonly IDepartmentRepository _depRepository;
        public LecturerDepDetailsController(ILecturerDepDetailsRepository lecturerDepDetailRepository, ILecturerAccountRepository lecturerAccountRepository, IDepartmentRepository departmentRepository){
            _lecturerDepDetailsRepository = lecturerDepDetailRepository;
            _lecturerAccountRepository = lecturerAccountRepository;
            _depRepository = departmentRepository;
        }
        [HttpGet("University/Faculty/Departments/Lecturer/Details")]
        [Authorize(Roles = "Lecturer")]
        public async Task<IActionResult> GetLecturerDepsDetails(){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);
            
            var depsDetails = await _lecturerDepDetailsRepository.GetLecturerDepsDetailsAsync(TC);
            
            return Ok(depsDetails);
        }
        [HttpGet("University/Faculty/Department/Lecturers/Details")]
        public async Task<IActionResult> GetDepsLecturers([FromQuery] String DepName){
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var depsLecturers = await _lecturerDepDetailsRepository.GetDepartmentsLecturersAsync(DepName);
            
            return Ok(depsLecturers);
        }
        [HttpGet("University/Faculty/Department/Lecturer/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetLecturerDepDetailByTcAndDepId([FromQuery] String TC, [FromQuery] String DepName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var lecturerDepDetail = await _lecturerDepDetailsRepository.GetLecturerDepDetailAsync(DepName, TC);

            if(lecturerDepDetail == null){
                return NotFound();
            }

            return Ok(lecturerDepDetail.ToLecturerDepDetailsDto());
        }
        [HttpPost("University/Faculty/Department/Lecturer/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddLecturerDepDetail([FromBody] LecturerDepDetailsPostDto lecturerDepDetailsPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validLecturer = await _lecturerAccountRepository.GetLecturerAccountByTCAsync(lecturerDepDetailsPostDto.TC);

            if(validLecturer == null){
                return BadRequest("Lecturer doesn't exist");
            }

            var validDep = await _depRepository.GetDepartmentAsync(lecturerDepDetailsPostDto.DepartmentName);

            if(validDep == null){
                return BadRequest("Department doesn't exist");
            }
            
            var depsDetails = await _lecturerDepDetailsRepository.AddLecturerToDepartment(lecturerDepDetailsPostDto.ToLecturerDepDetails());
            
            if(depsDetails == null){
                return BadRequest();
            }

            return Ok(depsDetails.ToLecturerDepDetailsDto());
        }
        [HttpPut("University/Faculty/Department/Lecturer/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateLecturerDepDetails([FromQuery] String TC, [FromQuery] String DepName, [FromBody] LecturerDepDetailsUpdateDto lecturerDepDetailsUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lecturerDepDetails = await _lecturerDepDetailsRepository.GetLecturerDepDetailAsync(DepName, TC);

            if(lecturerDepDetails == null){
                return NotFound();
            }

            if(lecturerDepDetails.TC != TC && lecturerDepDetails.DepartmentName != DepName){
                return BadRequest();
            }

            lecturerDepDetails.HoursPerWeek = lecturerDepDetailsUpdateDto.HoursPerWeek;
            lecturerDepDetails.EndDate = lecturerDepDetailsUpdateDto.EndDate;
            
            var updatedLecturerDepDetails = await _lecturerDepDetailsRepository.UpdateLecturerDepDetail(lecturerDepDetails);
            
            if(updatedLecturerDepDetails == null){
                return BadRequest();
            }

            return Ok(updatedLecturerDepDetails.ToLecturerDepDetailsDto());
        }
        [HttpDelete("University/Faculty/Departments/Lecturer/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStudentDepDetails([FromQuery] String TC, [FromQuery] String DepName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _lecturerDepDetailsRepository.DeleteLecturerDepDetail(DepName, TC);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
    }
}