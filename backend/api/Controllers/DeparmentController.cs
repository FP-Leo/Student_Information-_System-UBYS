
using api.DTO.Department;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DeparmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DeparmentController(IDepartmentRepository departmentRepository){
            _departmentRepository = departmentRepository;
        }
        [HttpGet("Department/{Id:int}")]
        public async Task<IActionResult> GetDepartmentById(int Id){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var department = await _departmentRepository.GetDepartmentByIdAsync(Id);

            if(department == null){
                return BadRequest();
            }

            return Ok(department.ToDepartmentDto());
        }
        [HttpPost("Department")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentPostDto departmentPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var department = await _departmentRepository.CreateDepartmentAsync(departmentPostDto.ToDepartment());
            
            if(department == null){
                return BadRequest();
            }

            return Ok(department.ToDepartmentDto());
        }
        [HttpPut("Department/{Id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDepartment(int Id, [FromBody] DepartmentUpdateDto departmentUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var department = await _departmentRepository.GetDepartmentByIdAsync(Id);

            if(department == null){
                return BadRequest();
            }

            if(departmentUpdateDto.DepartmentId != department.DepartmentId){
                return BadRequest();
            }

            department.BuildingNumber = departmentUpdateDto.BuildingNumber;
            department.FloorNumber = departmentUpdateDto.FloorNumber;
            department.HeadOfDepartmentTC = departmentUpdateDto.HeadOfDepartmentTC;
            
            var updatedDepartment = await _departmentRepository.UpdateDepartmentAsync(department);
            
            if(updatedDepartment == null){
                return BadRequest();
            }

            return Ok(updatedDepartment.ToDepartmentDto());
        }
        [HttpDelete("Department/{Id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDepartment(int Id){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _departmentRepository.DeleteDepartmentByIdAsync(Id);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
    }
}