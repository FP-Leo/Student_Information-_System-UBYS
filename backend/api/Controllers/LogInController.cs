using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTO.loginDtos;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LogInController: ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public LogInController(ApplicationDBContext context){
            _context = context;
        }
        /*
        [HttpGet]
        public IActionResult GetAll(){
            var loginInfos = _context.LogInInfos.ToList().Select(l => l.ToLogInInfoDto());
            return Ok(loginInfos);
        }
        */
        [HttpGet("{UserId}")]
        public IActionResult GetByUserId([FromRoute] int UserId){
            var loginInfo = _context.LogInInfos.FirstOrDefault(l => l.UserId == UserId);
            if(loginInfo==null){
                return NotFound();
            }
            return Ok(loginInfo.ToLogInInfoDto());
        }
        [HttpPost]
        public IActionResult CreateLogIn([FromBody] LogInInfoPostDto LIIdtoModel){
            var loginInfoModel = LIIdtoModel.ToLogInInfo();
            _context.Add(loginInfoModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetByUserId), new { UserId = loginInfoModel.UserId }, loginInfoModel.ToLogInInfoDto());
        }

        [HttpPut]
        public IActionResult UpdatePassword([FromBody] LogInInfoPutDto LIIdtoModel){
            var loginInfo = _context.LogInInfos.FirstOrDefault(l => l.UserId == LIIdtoModel.UserId && l.Password == LIIdtoModel.OldPassword );

            if(loginInfo==null){
                return NotFound();
            }

            loginInfo.Password = LIIdtoModel.NewPassword;

            _context.SaveChanges();

            return Ok(loginInfo.ToLogInInfoDto());
        }

        [HttpDelete]
        [Route("{UserId}")]
        public IActionResult DeleteLogInInfo([FromRoute] int UserId){
            var loginInfo = _context.LogInInfos.FirstOrDefault(l => l.UserId == UserId);

            if(loginInfo==null){
                return NotFound();
            }

            _context.LogInInfos.Remove(loginInfo);
            _context.SaveChanges();

            return NoContent();
        }
    }
}