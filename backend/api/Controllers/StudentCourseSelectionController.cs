using api.Mappers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.DTO.CourseSelection;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class StudentCourseSelectionController : ControllerBase
    {
        private readonly IStudentCourseSelectionRepository _courseSelectionDetailsRepo;
        private readonly IStudentCourseSelectRepository _selectedCoursesRepo;
        private readonly IDepartmentRepository _departmentRepo;
        private readonly ICourseRepository _courseRepository;
        private readonly IDepartmentCourseRepository _depCourseRepo;
        private readonly IStudentCourseDetailsRepository _studentDepDetailsRepo;
        private readonly IStudentCourseDetailsRepository _studentCourseDetailsRepo;
        private readonly ICourseClassRepository _courseClassRepository; 
        private readonly IUniversityRepository _universityRepository;
        private readonly ICourseDetailsRepository _courseDetailsRepository;
        public StudentCourseSelectionController(
            IStudentCourseSelectionRepository studentCourseSelectionRepository, IStudentCourseSelectRepository studentCourseSelectRepository,
            IDepartmentRepository departmentCourseSelectRepository, ICourseRepository courseRepository, IDepartmentCourseRepository departmentCourseRepository,
            IStudentCourseDetailsRepository studentDepDetailsRepo,  IStudentCourseDetailsRepository studentCourseDetailsRepository,
            ICourseClassRepository courseClassRepository, IUniversityRepository universityRepository, ICourseDetailsRepository courseDetailsRepository
        )
        {
            _courseSelectionDetailsRepo = studentCourseSelectionRepository;
            _selectedCoursesRepo = studentCourseSelectRepository;
            _departmentRepo = departmentCourseSelectRepository;
            _courseRepository = courseRepository;
            _depCourseRepo = departmentCourseRepository;
            _studentDepDetailsRepo = studentDepDetailsRepo;
            _studentCourseDetailsRepo = studentCourseDetailsRepository;
            _courseClassRepository = courseClassRepository;
            _universityRepository = universityRepository;
            _courseDetailsRepository = courseDetailsRepository;
        }

        [HttpGet("University/Faculty/Departments/Student/Course/Selection")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetCourseSelectionApi([FromQuery] String DepartmentName){
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);
            
            return await GetCourseSelection(DepartmentName, TC);
        }

        [HttpGet("University/Faculty/Departments/Advisor/Course/Selection")]
        [Authorize(Roles = "Advisor")]
        public async Task<IActionResult> GetStudentCourseSelectionApi([FromQuery] String DepartmentName, [FromQuery] String TC){
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            return await GetCourseSelection(DepartmentName, TC);
        }
        private async Task<IActionResult> GetCourseSelection(String DepartmentName, String TC){
            var depsDetails = await _studentDepDetailsRepo.GetStudentDepDetailAsync(TC, DepartmentName);

            if(depsDetails == null){
                return BadRequest("Student not registered on this department");
            }

            var courseSelectionDetails = await _courseSelectionDetailsRepo.GetCourseSelectionDetailsAsync(DepartmentName, TC);
            if(courseSelectionDetails == null){
                return BadRequest();
            }

            var selectedCourses = await _selectedCoursesRepo.GetSelectedCoursesAsync(DepartmentName, TC);
            if(selectedCourses == null){
                return BadRequest();
            }

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            if(uni == null){
                return BadRequest();
            }

            ICollection<CourseClass> courseClasses = [];
            foreach(var course in selectedCourses){
                var cClass = await _courseClassRepository.GetCourseClassAsync(course.CourseCode, uni.CurrentSchoolYear);
                if(cClass == null){
                    return BadRequest();
                }
                courseClasses.Add(cClass);
            }

            ICollection<SelectedCourseDto> selectedCourseDto = [];
            foreach(var cClass in courseClasses){
                var depCourse = await _depCourseRepo.GetDeparmentCourseByCourseCodeAsync(cClass.CourseCode);
                var courseDetails = await _courseDetailsRepository.GetCourseDetailsAsync(depCourse.CourseDetailsId);
                var selectedCourse = new SelectedCourseDto{
                    CourseCode = cClass.CourseCode,
                    ATKS = cClass.AKTS,
                    Kredi = cClass.Kredi,
                    LecturerTC = cClass.LecturerTC,
                    Type = courseDetails.CourseType,
                    TaughtSemester = depCourse.TaughtSemester
                };
                selectedCourseDto.Add(selectedCourse);
            }
            
            return Ok(courseSelectionDetails.ToCourseSelectionDetailsDto(selectedCourseDto));
        }
        [HttpPost("University/Faculty/Department/Student/Course/Selection")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> SendCourseSelection([FromBody] CourseSelectionPostDto courseSelectionPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentDepDetailsRepo = await _studentDepDetailsRepo.GetStudentDepDetailAsync(courseSelectionPostDto.TC, courseSelectionPostDto.DepartmentName);
            if(studentDepDetailsRepo == null){
                return BadRequest("Student not registered on this course.");
            }

            ICollection<CourseClass> courseClasses = [];
            ICollection<DepartmentCourse> depCourses = [];
            
            
            return Ok();
        }
    }
}