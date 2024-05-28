using api.DTO.ClassDate;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ClassDateController : ControllerBase
    {
        private readonly IClassDateRepository _classDateRepo;
        public ClassDateController(IClassDateRepository classDateRepository){
            _classDateRepo = classDateRepository;
        }
        [HttpGet("ClassDate/{Id:int}")]
        public async Task<IActionResult> GetClassDateById(int Id){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var classDate = await _classDateRepo.GetClassDateByIdAsync(Id);

            if(classDate == null){
                return BadRequest();
            }

            return Ok(classDate.ToClassDateDto());
        }
        [HttpPost("ClassDate")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddClassDate([FromBody] ClassDatePostDto classDatePostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var classDate = await _classDateRepo.CreateClassDateAsync(classDatePostDto.ToClassDate());
            
            if(classDate == null){
                return BadRequest();
            }

            return Ok(classDate.ToClassDateDto());
        }
        [HttpPut("ClassDate/{Id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateClassDate(int Id, [FromBody] ClassDateUpdateDto classDateUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classDate = await _classDateRepo.GetClassDateByIdAsync(Id);

            if(classDate == null){
                return BadRequest();
            }

            if(classDateUpdateDto.Id != classDate.Id){
                return BadRequest();
            }

            classDate.Id = classDateUpdateDto.Id;
            classDate.Day = classDateUpdateDto.Day;
            classDate.Time = classDateUpdateDto.Time;
            classDate.NumberOfClasses = classDateUpdateDto.NumberOfClasses;
        
            var updatedClassDate = await _classDateRepo.UpdateClassDateAsync(classDate);
            
            if(updatedClassDate == null){
                return BadRequest();
            }

            return Ok(updatedClassDate.ToClassDateDto());
        }

        [HttpDelete("ClassDate/{Id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteClassDate(int Id){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _classDateRepo.DeleteClassDateByIdAsync(Id);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }

    }
}