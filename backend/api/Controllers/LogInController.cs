using api.DTO.loginDtos;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LogInController: ControllerBase
    {
        private readonly ILogInInfoRepository _logInInfoRepository;
        public LogInController(ILogInInfoRepository logInInfoRepository){
            _logInInfoRepository = logInInfoRepository;
        }
        
        /*
        [HttpGet]
        public IActionResult GetAll(){
            var loginInfos = _context.LogInInfos.ToList().Select(l => l.ToLogInInfoDto());
            return Ok(loginInfos);
        }
        */

        [HttpGet("{UserId:int}")]
        public async Task<IActionResult> GetByUserId([FromRoute] int UserId){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var loginInfo = await _logInInfoRepository.GetLogInInfoAsyncByUserId(UserId);
            
            if(loginInfo == null){
                return NotFound();
            }

            return Ok(loginInfo.ToLogInInfoDto());
        }
        /*
        [HttpPost]
        public async Task<IActionResult> CreateLogIn([FromBody] LogInInfoPostDto LIIdtoModel){
            var loginInfoModel = LIIdtoModel.ToLogInInfo();

            var result = await _logInInfoRepository.CreateLogInInfoAsync(loginInfoModel);

            if(result == null){
                return StatusCode(500);
            }

            return CreatedAtAction(nameof(GetByUserId), new { UserId = loginInfoModel.UserId }, loginInfoModel.ToLogInInfoDto());
        }
        */
        [HttpPut]
        public async Task<IActionResult> UpdatePassword([FromBody] LogInInfoPutDto LIIdtoModel){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            
            var loginInfo = await _logInInfoRepository.GetLogInInfoAsyncByUserId(LIIdtoModel.UserId);

            if(loginInfo == null || loginInfo.Password != LIIdtoModel.OldPassword){
                return NotFound();
            }

            if(LIIdtoModel.NewPassword == null){
                return BadRequest();
            }

            var result = await _logInInfoRepository.UpdatePasswordAsync(loginInfo, LIIdtoModel.NewPassword);

            if(result == null){
                return StatusCode(500);
            }

            return Ok(result);
        }
        /*
        [HttpDelete]
        [Route("{UserId}")]
        public async Task<IActionResult> DeleteLogInInfo([FromRoute] int UserId){
            var loginInfo = await _logInInfoRepository.GetLogInInfoAsyncByUserId(UserId);

            if(loginInfo == null){
                return NotFound();
            }

            var deleted = await _logInInfoRepository.DeleteLogInInfoAsync(loginInfo);

            if(deleted == null){
                return StatusCode(500);
            }

            return NoContent();
        }
        */
    }
}