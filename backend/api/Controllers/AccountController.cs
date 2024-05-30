using api.DTO.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signinManager;
        private readonly IStudentAccountRepository _studentAccountRepository;
        private readonly ILecturerAccountRepository _lecturerAccountRepository;
        private readonly IAdvisorAccountRepository _advisorAccountRepository;
        private readonly IAdministratorAccountRepository _administratorAccountRepository;
        private readonly IStudentDepDetailsRepository _studentDepDetailsRepository;
        private readonly ILecturerDepDetailsRepository _lecturerDepDetailsRepository;
        public AccountController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager, IStudentAccountRepository studentAccountRepository, ILecturerAccountRepository lecturerAccountRepository,IAdvisorAccountRepository advisorAccountRepository,IAdministratorAccountRepository administratorAccountRepository, IStudentDepDetailsRepository studentDepDetailsRepository, ILecturerDepDetailsRepository lecturerDepDetailsRepository)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signInManager;
            _studentAccountRepository = studentAccountRepository;
            _lecturerAccountRepository = lecturerAccountRepository;
            _advisorAccountRepository = advisorAccountRepository;
            _administratorAccountRepository  = administratorAccountRepository;
            _studentDepDetailsRepository = studentDepDetailsRepository;
            _lecturerDepDetailsRepository = lecturerDepDetailsRepository;
        }
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
        //Function to register any type of user.
        [HttpPost("Admin/System/Account/Register")]
        //[Authorize(Roles = "Admin")]
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
        [HttpPost("Admin/System/Account/Register/Student")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentDto registerStudentDto){
            if(registerStudentDto.CurrentType != "Bachelor" && registerStudentDto.CurrentType != "Master" && registerStudentDto.CurrentType != "Doctoral" && registerStudentDto.CurrentType != "Associate"){
                return BadRequest("Bad input on the student type.");
            }

            if(registerStudentDto.CurrentStatus != "Active" && registerStudentDto.CurrentStatus != "Frozen"){
                return BadRequest("Bad input on the student status.");
            }
            
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
                        var newStudentAccPost = registerStudentDto.ToStudentAccount(registerStudentDto.Username);

                        try{
                            var newStudentAcc = await _studentAccountRepository.CreateStudentAccountAsync(newStudentAccPost);
                            if (newStudentAcc == null){
                                var result = await _userManager.DeleteAsync(appUser);
                                return StatusCode(500, "Error creating the account!");
                            }
                            return Ok(newStudentAcc.ToStudentAccountLOGINDto(_tokenService.CreateToken(appUser), null));
                        }catch( Exception e ){
                            await _userManager.DeleteAsync(appUser);
                            return StatusCode(500, e);
                        }
                    }
                    else
                    {
                        await _userManager.DeleteAsync(appUser);
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    await _userManager.DeleteAsync(appUser);
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e){
                return StatusCode(500, e);
            }
        }
        [HttpPost("Admin/System/Account/Register/Lecturer")]
        [Authorize(Roles = "Admin")]
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
                        var newLecturerAccPost = registerLecturerDto.ToLecturerAccount(registerLecturerDto.Username);
                        try{
                            var newLecturerAcc = await _lecturerAccountRepository.CreateLecturerAccountAsync(newLecturerAccPost);

                            if (newLecturerAcc == null){
                                await _userManager.DeleteAsync(appUser);
                                return StatusCode(500, "Error creating the account!");
                            }

                            return Ok(newLecturerAcc.ToLecturerAccountLOGINDto(_tokenService.CreateToken(appUser), null));
                        }
                        catch (Exception e){
                            await _userManager.DeleteAsync(appUser);
                            return StatusCode(500, e);
                        }
                    }
                    else
                    {
                        await _userManager.DeleteAsync(appUser);
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    await _userManager.DeleteAsync(appUser);
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e){
                return StatusCode(500, e);
            }
        }
        // Advisor controller
        [HttpPost("Admin/System/Account/Register/Advisor")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterAdvisor([FromBody] RegisterAdvisorDto registerAdvisorDto){
            try{
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if(registerAdvisorDto.Username == null || registerAdvisorDto.Password == null)
                    return BadRequest();

                if(InvalidTC(registerAdvisorDto.Username))
                    return BadRequest();

                var appUser = new User
                {
                    UserName = registerAdvisorDto.Username,
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerAdvisorDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "Advisor");
                    if (roleResult.Succeeded)
                    {
                        var newAdvisorAccPost = registerAdvisorDto.ToAdvisorAccount(registerAdvisorDto.Username);
                        try{
                            var newAdvisorAcc = await _advisorAccountRepository.CreateAdvisorAccountAsync(newAdvisorAccPost);

                            if (newAdvisorAcc == null){
                                await _userManager.DeleteAsync(appUser);
                                return StatusCode(500, "Error creating the account!");
                            }
                            return Ok(newAdvisorAcc.ToAdvisorAccountLOGINDto(_tokenService.CreateToken(appUser)));
                        }
                        catch (Exception e){
                            await _userManager.DeleteAsync(appUser);
                            return StatusCode(500, e);
                        }
                    }
                    else
                    {
                        await _userManager.DeleteAsync(appUser);
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    await _userManager.DeleteAsync(appUser);
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e){
                return StatusCode(500, e);
            }
        }
        // administrator controller
        [HttpPost("Admin/System/Account/Register/Administrator")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterAdministrator([FromBody] RegisterAdministratorDto registerAdministratorDto){
            try{
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if(registerAdministratorDto.Username == null || registerAdministratorDto.Password == null)
                    return BadRequest();

                if(InvalidTC(registerAdministratorDto.Username))
                    return BadRequest();

                var appUser = new User
                {
                    UserName = registerAdministratorDto.Username,
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerAdministratorDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "Administrator");
                    if (roleResult.Succeeded)
                    {
                        var newAdministratorAccPost = registerAdministratorDto.ToAdministratorAccount(registerAdministratorDto.Username);
                        try{     
                            var newAdministratorAcc = await _administratorAccountRepository.CreateAdministratorAccountAsync(newAdministratorAccPost);

                            if (newAdministratorAcc == null){
                                await _userManager.DeleteAsync(appUser);
                                return StatusCode(500, "Error creating the account!");
                            }
                            return Ok(newAdministratorAcc.ToAdministratorAccountLOGINDto(_tokenService.CreateToken(appUser)));
                        }catch (Exception e){
                            await _userManager.DeleteAsync(appUser);
                            return StatusCode(500, e);
                        }
                    }
                    else
                    {
                        await _userManager.DeleteAsync(appUser);
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    await _userManager.DeleteAsync(appUser);
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e){
                return StatusCode(500, e);
            }
        }
        //Log In Function
        [HttpPost("System/Account/LogIn")]
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

                var deps = await _studentDepDetailsRepository.GetStudentDepDetailsByTCAsync(loginDto.Username);

                return Ok(acc.ToStudentAccountLOGINDto(_tokenService.CreateToken(user), deps));
            }

            if(userRoles[0] == "Lecturer"){
                var acc = await _lecturerAccountRepository.GetLecturerAccountByTCAsync(loginDto.Username);

                if(acc == null){
                    return StatusCode(500, "Account not found!");
                }

                var deps = await _lecturerDepDetailsRepository.GetLecturerDepsDetailsAsync(loginDto.Username);


                return Ok(acc.ToLecturerAccountLOGINDto(_tokenService.CreateToken(user), deps));
            }

            if(userRoles[0] == "Advisor"){
                var acc = await _advisorAccountRepository.GetAdvisorAccountByTCAsync(loginDto.Username);

                if(acc == null){
                    return StatusCode(500, "Account not found!");
                }

                return Ok(acc.ToAdvisorAccountLOGINDto(_tokenService.CreateToken(user)));
            }

            if(userRoles[0] == "Administrator"){
                var acc = await _administratorAccountRepository.GetAdministratorAccountByTCAsync(loginDto.Username);

                if(acc == null){
                    return StatusCode(500, "Account not found!");
                }

                return Ok(acc.ToAdministratorAccountLOGINDto(_tokenService.CreateToken(user)));
            }

            return Ok(new NewUserDto{
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            });

            //return StatusCode(500, "Account not found!");
        }
    }
}