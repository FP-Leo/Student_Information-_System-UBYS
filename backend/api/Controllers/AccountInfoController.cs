using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AccountInfoController: ControllerBase
    {
        private readonly IStudentAccountRepository _studentAccRepo;

        public AccountInfoController(IStudentAccountRepository studentAccRepo){
            _studentAccRepo = studentAccRepo;
        }

        [HttpGet("Student/AccountInfo/{TC}")]
        public async Task<IActionResult> GetByTc(string TC){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(TC.Length != 11)
            {
                return BadRequest("TC must be 11 characters long.");
            }

            foreach(char c in TC){
                if(!System.Char.IsDigit(c)){
                    return BadRequest("TC can only contain integers.");
                }
            }

            var accInfo = await _studentAccRepo.GetStudentAccountByTCAsync(TC); 

            if(accInfo == null){
                return NotFound();
            }

            return Ok(accInfo.ToStudentAccountDto());
        }
        
        [HttpGet("Student/AccountInfo/{SSN:int}")]
        public async Task<IActionResult> GetBySsn(int SSN){
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
    }
}