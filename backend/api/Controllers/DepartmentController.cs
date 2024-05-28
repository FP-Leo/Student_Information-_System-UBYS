
using api.DTO.Department;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository){
            _departmentRepository = departmentRepository;
        }
        [HttpGet("University/Faculty/Department/")]
        public async Task<IActionResult> GetDepartment([FromQuery] String DepartmentName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var department = await _departmentRepository.GetDepartmentAsync(DepartmentName);

            if(department == null)
                return NotFound();

            return Ok(department.ToDepartmentDto());
        }
        [HttpGet("University/Faculty/Departments/")]
        public async Task<IActionResult> GetDepartmentsOfFaculty([FromQuery] String FacultyName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var departments = await _departmentRepository.GetDepartmentsOfFacultyAsync(FacultyName);

            if(departments == null){
                return BadRequest();
            }

            return Ok(departments);
        }
        [HttpPost("University/Faculty/Department/")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentPostDto departmentPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var department = await _departmentRepository.CreateDepartmentAsync(departmentPostDto.ToDepartment());
            
            if(department == null)
                return BadRequest();

            return Ok(department.ToDepartmentDto());
        }
        [HttpPut("University/Faculty/Department/")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDepartment([FromQuery] String DepartmentName, [FromBody] DepartmentUpdateDto departmentUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var department = await _departmentRepository.GetDepartmentAsync(DepartmentName);

            if(department == null)
                return NotFound();

            if(departmentUpdateDto.DepartmentName != department.DepartmentName)
                return BadRequest();
            
            department.NumberOfSemesters = departmentUpdateDto.NumberOfSemesters;
            department.MaxYears = departmentUpdateDto.MaxYears;
            department.BuildingNumber = departmentUpdateDto.BuildingNumber;
            department.FloorNumber = departmentUpdateDto.FloorNumber;
            department.HeadOfDepartmentTC = departmentUpdateDto.HeadOfDepartmentTC;
            
            var updatedDepartment = await _departmentRepository.UpdateDepartmentAsync(department);
            
            if(updatedDepartment == null){
                return BadRequest();
            }

            return Ok(updatedDepartment.ToDepartmentDto());
        }
        [HttpDelete("University/Faculty/Department/")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDepartment([FromQuery] String DepartmentName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _departmentRepository.DeleteDepartmentAsync(DepartmentName);

            if(result == null)
                return BadRequest();

            return NoContent();
        }
    }
}