using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mappers;
using api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class StudentDepDetailsController: ControllerBase
    {
        private readonly IStudentDepDetailsRepository _studentDepDetailsRepository;

        public StudentDepDetailsController(IStudentDepDetailsRepository studentDepDetailsRepository){
            _studentDepDetailsRepository = studentDepDetailsRepository;
        }
        [HttpGet("Student/Departments/Details")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetDepsDetails(){
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);
            
            var depsDetails = await _studentDepDetailsRepository.GetStudentDepDetailsByTC(TC);
            
            return Ok(depsDetails);
        }

        [HttpGet("Student/Department/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetDepDetailByTcAndDepId([FromQuery] String TC, [FromQuery] int DepId){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var studentDepDetails = await _studentDepDetailsRepository.GetStudentDepDetailByTcAndDepId(TC, DepId);

            if(studentDepDetails == null){
                return BadRequest();
            }

            return Ok(studentDepDetails.ToStudentDepDetailsDto());
        }

        [HttpDelete("Student/Department/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStudentDepDetails([FromQuery] String TC, [FromQuery] int DepId){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _studentDepDetailsRepository.DeleteStudentDepDetail(TC, DepId);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
    }
}