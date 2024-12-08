using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.SemesterDetails;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.MappingProfiles;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SemesterDetailsController : ControllerBase
    {
        private readonly ISemesterDetailsRepository _semesterDetailsRepo;
        private readonly IDepartmentRepository _departmentRepo;
        public SemesterDetailsController(ISemesterDetailsRepository semesterDetailsRepository, IDepartmentRepository departmentRepository){
            _semesterDetailsRepo = semesterDetailsRepository;
            _departmentRepo = departmentRepository;
        }
        [HttpGet("University/Faculty/Department/Semester")]
        public async Task<IActionResult> GetDepSemesterDetails([FromQuery] String DepartmentName, [FromQuery] int Semester){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var semesterDetails = await _semesterDetailsRepo.GetSemesterDetailsAsync(DepartmentName, Semester);

            if(semesterDetails == null){
                return BadRequest();
            }

            return Ok(semesterDetails.ToSemesterDetailsDto());
        }
        [HttpPost("University/Faculty/Department/Semester")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddSemesterDetails([FromBody] SemesterDetailsPostDto semesterDetailsPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dep = await _departmentRepo.GetDepartmentAsync(semesterDetailsPostDto.DepartmentName);
            if(dep == null){
                return BadRequest("Department not found!");
            }

            if(dep.NumberOfSemesters < semesterDetailsPostDto.Semester || semesterDetailsPostDto.Semester <= 0){
                return BadRequest("Invalid Semester");
            }
            
            var semesterDetails = await _semesterDetailsRepo.AddSemesterDetailsAsync(semesterDetailsPostDto.ToSemesterDetails());
            
            if(semesterDetails == null){
                return BadRequest();
            }

            return Ok(semesterDetails.ToSemesterDetailsDto());
        }
        [HttpPut("University/Faculty/Department/Semester")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateemesterDetails([FromQuery] String  DeparmentName,[FromQuery] int Semester, [FromBody] SemesterDetailsUpdateDto semesterDetailsUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(semesterDetailsUpdateDto.DepartmentName != DeparmentName){
                return BadRequest();
            }

            var dep = await _departmentRepo.GetDepartmentAsync(DeparmentName);

            if(dep == null){
                return BadRequest("Department not found!");
            }

            var semesterDetails = await _semesterDetailsRepo.GetSemesterDetailsAsync(DeparmentName, Semester);

            if(semesterDetails == null){
                return BadRequest("Department not found!");
            }        

            semesterDetails.NumberOfObligatoryCourses = semesterDetailsUpdateDto.NumberOfObligatoryCourses;
            semesterDetails.NumberOfSelectiveCourses = semesterDetailsUpdateDto.NumberOfSelectiveCourses;
            semesterDetails.SelectiveCourseACTS = semesterDetailsUpdateDto.SelectiveCourseACTS;
            semesterDetails.SelectiveCourseKredi = semesterDetailsUpdateDto.SelectiveCourseKredi;
            
            var updatedSemesterDetails = await _semesterDetailsRepo.UpdateSemesterDetailsAsync(semesterDetails);
            
            if(updatedSemesterDetails == null){
                return BadRequest();
            }

            return Ok(updatedSemesterDetails.ToSemesterDetailsDto());
        }
        [HttpDelete("University/Faculty/Department/Semester")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSemesterDetails([FromQuery] String  DeparmentName,[FromQuery] int Semester){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _semesterDetailsRepo.DeleteSemesterDetailsAsync(DeparmentName, Semester);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
    }
}