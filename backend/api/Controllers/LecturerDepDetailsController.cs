using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using api.DTO.LecturerDepDetails;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LecturerDepDetailsController: ControllerBase
    {
        private readonly ILecturerDepDetailsRepository _lecturerDepDetailsRepository;
        private readonly ILecturerAccountRepository _lecturerAccountRepository;
        private readonly IDepartmentRepository _depRepository;
        private readonly ICourseClassRepository _courseClassRepository;
        private readonly IUniversityRepository _universityRepository;
        private readonly IDepartmentCourseRepository _departmentCourseRepository;
        public LecturerDepDetailsController(ILecturerDepDetailsRepository lecturerDepDetailRepository,
         ILecturerAccountRepository lecturerAccountRepository, IDepartmentRepository departmentRepository,
         ICourseClassRepository courseClassRepository, IUniversityRepository universityRepository,
         IDepartmentCourseRepository departmentCourseRepository){
            _lecturerDepDetailsRepository = lecturerDepDetailRepository;
            _lecturerAccountRepository = lecturerAccountRepository;
            _depRepository = departmentRepository;
            _courseClassRepository = courseClassRepository;
            _universityRepository = universityRepository;
            _departmentCourseRepository = departmentCourseRepository;
        }
        [HttpGet("University/Faculty/Departments/Lecturer/Details")]
        [Authorize(Roles = "Lecturer")]
        public async Task<IActionResult> GetLecturerDepsDetails(){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);
            
            var depsDetails = await _lecturerDepDetailsRepository.GetLecturerDepsDetailsAsync(TC);
            
            return Ok(depsDetails);
        }
        [HttpGet("University/Faculty/Department/Lecturers/Details")]
        public async Task<IActionResult> GetDepsLecturers([FromQuery] String DepName){
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var depsLecturers = await _lecturerDepDetailsRepository.GetDepartmentsLecturersAsync(DepName);
            
            return Ok(depsLecturers);
        }
        [HttpGet("University/Faculty/Department/Lecturer/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetLecturerDepDetailByTcAndDepId([FromQuery] String TC, [FromQuery] String DepName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var lecturerDepDetail = await _lecturerDepDetailsRepository.GetLecturerDepDetailAsync(DepName, TC);

            if(lecturerDepDetail == null){
                return NotFound();
            }

            return Ok(lecturerDepDetail.ToLecturerDepDetailsDto());
        }
        [HttpPost("University/Faculty/Department/Lecturer/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddLecturerDepDetail([FromBody] LecturerDepDetailsPostDto lecturerDepDetailsPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validLecturer = await _lecturerAccountRepository.GetLecturerAccountByTCAsync(lecturerDepDetailsPostDto.TC);

            if(validLecturer == null){
                return BadRequest("Lecturer doesn't exist");
            }

            var validDep = await _depRepository.GetDepartmentAsync(lecturerDepDetailsPostDto.DepartmentName);

            if(validDep == null){
                return BadRequest("Department doesn't exist");
            }
            
            var depsDetails = await _lecturerDepDetailsRepository.AddLecturerToDepartment(lecturerDepDetailsPostDto.ToLecturerDepDetails());
            
            if(depsDetails == null){
                return BadRequest();
            }

            return Ok(depsDetails.ToLecturerDepDetailsDto());
        }
        [HttpPut("University/Faculty/Department/Lecturer/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateLecturerDepDetails([FromQuery] String TC, [FromQuery] String DepName, [FromBody] LecturerDepDetailsUpdateDto lecturerDepDetailsUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lecturerDepDetails = await _lecturerDepDetailsRepository.GetLecturerDepDetailAsync(DepName, TC);

            if(lecturerDepDetails == null){
                return NotFound();
            }

            if(lecturerDepDetails.TC != TC && lecturerDepDetails.DepartmentName != DepName){
                return BadRequest();
            }

            lecturerDepDetails.HoursPerWeek = lecturerDepDetailsUpdateDto.HoursPerWeek;
            lecturerDepDetails.EndDate = lecturerDepDetailsUpdateDto.EndDate;
            
            var updatedLecturerDepDetails = await _lecturerDepDetailsRepository.UpdateLecturerDepDetail(lecturerDepDetails);
            
            if(updatedLecturerDepDetails == null){
                return BadRequest();
            }

            return Ok(updatedLecturerDepDetails.ToLecturerDepDetailsDto());
        }
        [HttpDelete("University/Faculty/Departments/Lecturer/Details")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteLecturerDepDetails([FromQuery] String TC, [FromQuery] String DepName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _lecturerDepDetailsRepository.DeleteLecturerDepDetail(DepName, TC);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
        [HttpGet("University/Faculty/Department/Lecturer/Courses")]
        [Authorize(Roles = "Lecturer")]
        public async Task<IActionResult> GetOwnCourses([FromQuery] String DepartmentName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            return await LecturerCourses(DepartmentName, TC);
        }
        [HttpGet("University/Faculty/Administrator/Lecturer/Courses")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetLecturersAllCourses([FromQuery] int ID){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lecturer = await _lecturerAccountRepository.GetLecturerAccountByIDAsync(ID);
            if(lecturer == null){
                return NotFound("There's no lecturer registered with that ID");
            }
            
            var depsDetails = await _lecturerDepDetailsRepository.GetLecturerDepsDetailsAsync(lecturer.TC);

            if(depsDetails == null){
                return NotFound("Lecturer not registered on any department.");
            }

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            if(uni == null){
                return StatusCode(500, "Failed to get university data.");
            }
            ICollection<LecturerDetailedCourseDto> allCourses = [];

            foreach(var depDetail in depsDetails){
                var classes = await _courseClassRepository.GetLecturersDepClasses(depDetail.DepartmentName, lecturer.TC, uni.CurrentSchoolYear);
                foreach(var cc in classes){
                    var depCourse = await _departmentCourseRepository.GetDeparmentCourseByCourseCodeAsync(cc.CourseCode);
                    LecturerDetailedCourseDto dto = new LecturerDetailedCourseDto{
                        CourseCode = cc.CourseCode,
                        CourseName = depCourse.CourseName,
                        Department = depCourse.DepartmentName,
                        Kredi = cc.Kredi,
                        AKTS = cc.AKTS,
                    };
                    allCourses.Add(dto);
                }
            }

            return Ok(allCourses);
        }
        [HttpGet("University/Faculty/Administrator/Lecturers")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetAllLecturers(){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lecturers = await _lecturerAccountRepository.GetLecturerAccounts();
            ICollection<LectureSchoolDetailsDto> lecturersInfo = [];

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            if(uni == null){
                return StatusCode(500, "Failed to get university data.");
            }

            foreach(var lecturer in lecturers){
                var details = new LectureSchoolDetailsDto{
                    ID = lecturer.ID,
                    Name = lecturer.FirstName + " " + lecturer.LastName,
                    Faculties = [],
                    CurrentState = lecturer.CurrentStatus
                };
                var depsDetails = await _lecturerDepDetailsRepository.GetLecturerDepsDetailsAsync(lecturer.TC);
                foreach(var depDetail in depsDetails){
                    var dep = await _depRepository.GetDepartmentAsync(depDetail.DepartmentName);
                    var facultyInfo = new LecturerFacultyDetailsDto{
                        FacultyName = dep.FacultyName,
                        DepartmentName = dep.DepartmentName
                    };
                    details.Faculties.Add(facultyInfo);
                }
                lecturersInfo.Add(details);
            }
            return Ok(lecturersInfo);
        }  
        [HttpGet("University/Faculty/Department/Administrator/Lecturer/Courses")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetLecturerCoursesByDeparment([FromQuery] String DepartmentName, [FromQuery] int ID){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lecturer = await _lecturerAccountRepository.GetLecturerAccountByIDAsync(ID);
            if(lecturer == null){
                return NotFound("There's no lectuerer registered with that ID");
            }

            return await LecturerCourses(DepartmentName, lecturer.TC);
        }
        private async Task<IActionResult> LecturerCourses(String DepartmentName, String TC){
            var dep = await _depRepository.GetDepartmentAsync(DepartmentName);
            if(dep == null){
                return BadRequest("Department doesn't exist.");
            }
            
            var depsDetails = await _lecturerDepDetailsRepository.GetLecturerDepDetailAsync(DepartmentName, TC);
            if(depsDetails == null){
                return NotFound("You're not registered on that department.");
            }

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            if(uni == null){
                return StatusCode(500, "Failed to get university data.");
            }

            LecturerCoursesDto lecturerCoursesDtos = new()
            {
                CourseFaculty = dep.FacultyName,
                CourseDepartment = dep.DepartmentName,
                Courses = []
            };

            var classes = await _courseClassRepository.GetLecturersDepClasses(DepartmentName, TC, uni.CurrentSchoolYear);
            foreach(var cc in classes){
                var depCourse = await _departmentCourseRepository.GetDeparmentCourseByCourseCodeAsync(cc.CourseCode);
                string? CourseSemester;
                if (depCourse.TaughtSemester % 2 == 0){
                    CourseSemester = "Bahar";
                }else{
                    CourseSemester = "Güz";
                }
                LecturerCourseDto dto = new LecturerCourseDto{
                    CourseCode = cc.CourseCode,
                    CourseName = depCourse.CourseName,
                    CourseSemester = CourseSemester,
                    SchoolYear = uni.CurrentSchoolYear
                };
                lecturerCoursesDtos.Courses.Add(dto);
            }

            return Ok(lecturerCoursesDtos);
        }
    }
}