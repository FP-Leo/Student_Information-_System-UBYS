using api.DTO.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using api.Mappers;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signinManager;
        private readonly IStudentAccountRepository _studentAccountRepository;
        private readonly ILecturerAccountRepository _lecturerAccountRepository;
        public AccountController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager, IStudentAccountRepository studentAccountRepository, ILecturerAccountRepository lecturerAccountRepository)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signInManager;
            _studentAccountRepository = studentAccountRepository;
            _lecturerAccountRepository = lecturerAccountRepository;
        }
        //Function to register any type of user.
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto){
            try{
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if(registerDto.Username == null || registerDto.Username.Length != 11)
                    return StatusCode(403, "Invalid TC. TC must be 11 characters long.");

                foreach(char c in registerDto.Username){
                    if(!System.Char.IsDigit(c))
                        return StatusCode(403, "Invalid TC. TC contains only int characters.");
                }

                if(registerDto.Password == null)
                    return BadRequest();
            
                if(registerDto.Role == null || (!registerDto.Role.Equals("Student")  && !registerDto.Role.Equals("Lecturer")  && !registerDto.Role.Equals("Advisor")  && !registerDto.Role.Equals("Administrator") && !registerDto.Role.Equals("Admin")))
                    return StatusCode(403,"Role doesn't exist." );

                var appUser = new User
                {
                    UserName = registerDto.Username,
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, registerDto.Role);
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto{
                                UserName = appUser.UserName,
                                Token = _tokenService.CreateToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e){
                return StatusCode(500, e);
            }
        }
        //Function to register students only, for backend admins.
        [HttpPost("register/student")]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentDto registerStudentDto){
            try{
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                if(registerStudentDto.Username == null || registerStudentDto.Password == null)
                    return BadRequest();

                if(InvalidTC(registerStudentDto.Username))
                    return BadRequest();

                var appUser = new User
                {
                    UserName = registerStudentDto.Username,
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerStudentDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "Student");
                    if (roleResult.Succeeded)
                    {
                        var id = await _userManager.GetUserIdAsync(appUser);

                        var newStudentAccPost = registerStudentDto.ToStudentAccount(id);

                        var newStudentAcc = await _studentAccountRepository.CreateStudentAccountAsync(newStudentAccPost);

                        if (newStudentAcc == null){
                            return StatusCode(500, "Error creating the account!");
                        }
                        return Ok(newStudentAcc.ToStudentAccountDto());
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e){
                return StatusCode(500, e);
            }
        }
        [HttpPost("register/lecturer")]
        public async Task<IActionResult> RegisterLecturer([FromBody] RegisterLecturerDto registerLecturerDto){
            try{
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if(registerLecturerDto.Username == null || registerLecturerDto.Password == null)
                    return BadRequest();

                if(InvalidTC(registerLecturerDto.Username))
                    return BadRequest();

                var appUser = new User
                {
                    UserName = registerLecturerDto.Username,
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerLecturerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "Lecturer");
                    if (roleResult.Succeeded)
                    {
                        var id = await _userManager.GetUserIdAsync(appUser);

                        var newLecturerAccPost = registerLecturerDto.ToLecturerAccount(id);

                        var newLecturerAcc = await _lecturerAccountRepository.CreateLecturerAccountAsync(newLecturerAccPost);

                        if (newLecturerAcc == null){
                            return StatusCode(500, "Error creating the account!");
                        }
                        return Ok(newLecturerAcc.ToLecturerAccountLOGINDto());
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e){
                return StatusCode(500, e);
            }
        }
        //[HttpPost("register/advisor")]
        //[HttpPost("register/administrator")]
        //After the above HttpPosts are implemented the [HttpPost("register")] can be deleted
        
        // Function to validate TC.
        private bool InvalidTC(string TC){
            if(TC.Length != 11)
                return true;

            foreach(char c in TC){
                if(!System.Char.IsDigit(c))
                    return true;
            }

            return false;
        }
        //Log In Function
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(loginDto == null || loginDto.Username == null || loginDto.Password == null){
                return BadRequest();
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

            if (user == null) return Unauthorized("Invalid username!");

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Username not found and/or password incorrect");

            IList<string> userRoles = await _userManager.GetRolesAsync(user);
            //Check current user's role and return the appropriate info to the front end.
            if(userRoles[0] == "Student"){
                var acc = await _studentAccountRepository.GetStudentAccountByTCAsync(loginDto.Username);

                if(acc == null){
                    return StatusCode(500, "Account not found!");
                }

                return Ok(acc.ToStudentAccountLOGINDto());
            }

            if(userRoles[0] == "Lecturer"){
                var acc = await _lecturerAccountRepository.GetLecturerAccountByTCAsync(loginDto.Username);

                if(acc == null){
                    return StatusCode(500, "Account not found!");
                }

                return Ok(acc.ToLecturerAccountLOGINDto());
            }

            //if(userRoles[0] == "Advisor"){}

            //if(userRoles[0] == "Administrator"){}

            //After the above ifs are implemented the below return Ok can be deleted.

            return Ok(
                new NewUserDto
                {
                    UserName = user.UserName,
                    Token = _tokenService.CreateToken(user)
                }
            );
        }

    }
}