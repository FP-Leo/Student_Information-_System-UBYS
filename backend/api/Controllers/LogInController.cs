using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
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

        [HttpGet]
        public IActionResult GetAll(){
            var loginInfos = _context.LogInInfos.ToList();
            return Ok(loginInfos);
        }

        [HttpGet("{id}")]
         public IActionResult GetById([FromRoute] int id){
            var loginInfo = _context.LogInInfos.Find(id);
            if(loginInfo==null){
                return NotFound("");
            }
            return Ok(loginInfo);
        }
    }
}