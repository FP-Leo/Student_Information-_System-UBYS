using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.CourseClassDate;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.MappingProfiles;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CourseClassDateController : ControllerBase
    {
        private readonly ICourseClassDateRepository _courseClassDateRepo;
        private readonly ICourseClassRepository _courseClassRepo;
        private readonly IClassDateRepository _classDateRepo;
        private readonly IDepartmentCourseRepository _departmentCourseRepo;
        private readonly IStudentCourseDetailsRepostiory _studentCourseDetailsRepo;
        private readonly IUniversityRepository _universityRepo;
        public CourseClassDateController(ICourseClassDateRepository courseClassDateRepository, IClassDateRepository classDateRepository, IDepartmentCourseRepository departmentCourseRepository, IStudentCourseDetailsRepostiory studentDepDetailsRepository, ICourseClassRepository courseClassRepository, IUniversityRepository universityRepository){
            _courseClassDateRepo = courseClassDateRepository;
            _classDateRepo = classDateRepository;
            _departmentCourseRepo = departmentCourseRepository;
            _studentCourseDetailsRepo = studentDepDetailsRepository;
            _courseClassRepo = courseClassRepository;
            _universityRepo = universityRepository;
        }
        [HttpGet("University/Faculty/Department/Student/Dates/")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetStudentDates([FromQuery] String DepartmentName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CurrentTC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            var attendingClasses = await _studentCourseDetailsRepo.GetActiveCoursesAsync(DepartmentName, CurrentTC);
            
            ScheduleDto holder = new();
            holder.Dates = [];
            foreach(var cls in attendingClasses){
                var depCls = await _departmentCourseRepo.GetDeparmentCourseByCourseCodeAsync(cls.CourseCode);
                var courseClassDates = await _courseClassDateRepo.GetCourseClassDatesAsync(cls.CourseCode);
                holder.Dates.Add(await courseClassDates.ToCourseClassDatesDto(_classDateRepo, depCls.CourseName));
            }

            return Ok(holder);
        }
        [HttpGet("University/Faculty/Department/Lecturer/Dates/")]
        [Authorize(Roles = "Lecturer")]
        public async Task<IActionResult> GetLecturerDates([FromQuery] String DepartmentName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CurrentTC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            var uni = await _universityRepo.GetUniversityByIdAsync(1);
            if(uni == null){
                return StatusCode(500, "Failed to fetch university data.");
            }

            var attendingClasses = await _courseClassRepo.GetLecturersDepClasses(DepartmentName, CurrentTC, uni.CurrentSchoolYear);
            
            ScheduleDto holder = new();
            holder.Dates = [];
            foreach(var cls in attendingClasses){
                var depCls = await _departmentCourseRepo.GetDeparmentCourseByCourseCodeAsync(cls.CourseCode);
                var courseClassDates = await _courseClassDateRepo.GetCourseClassDatesAsync(cls.CourseCode);
                holder.Dates.Add(await courseClassDates.ToCourseClassDatesDto(_classDateRepo, depCls.CourseName));
            }

            return Ok(holder);
        }
        [HttpGet("University/Faculty/Department/Course/Class/Dates/")]
        public async Task<IActionResult> GetCourseClassDates([FromQuery] String DepartmentName, String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var depCourse = await _departmentCourseRepo.GetDeparmentCourseAsync(DepartmentName, CourseName);
            if(depCourse == null){
                return NotFound();
            }
            
            var courseClassDates = await _courseClassDateRepo.GetCourseClassDatesAsync(depCourse.CourseCode);

            if(courseClassDates == null){
                return BadRequest();
            }

            return Ok(await courseClassDates.ToCourseClassDatesDto(_classDateRepo, CourseName));
        }
        [HttpPost("University/Faculty/Department/Course/Class/Dates/")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCourseClassDates([FromBody] CourseClassDatePostDto courseClassDatePostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ClassDates = courseClassDatePostDto.GetClassDates();

            if(ClassDates == null){
                return BadRequest();
            }

            foreach(var cls in ClassDates){
                var classDate = await _classDateRepo.GetClassDateIdAsync(cls.Day, cls.Time, cls.NumberOfClasses);
                if(classDate == null){
                    classDate = await _classDateRepo.CreateClassDateAsync(classDate);
                    if(classDate == null){
                        return StatusCode(500);
                    }
                }
                var courseClassDate = await _courseClassDateRepo.CreateCourseClassDateAsync(courseClassDatePostDto.ToCourseClassDate(classDate.Id));
                if(courseClassDate == null){
                    return StatusCode(500);
                }
            }

            return Ok();
        }
        [HttpDelete("University/Faculty/Department/Course/Class/Dates/")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCourseClassDates([FromQuery] String DepartmentName, [FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var depCourse = await _departmentCourseRepo.GetDeparmentCourseAsync(DepartmentName, CourseName);
            if(depCourse == null){
                return NotFound();
            }

            var result = await _courseClassDateRepo.GetCourseClassDatesAsync(depCourse.CourseCode);

            if(result == null){
                return BadRequest();
            }

            foreach(var cls in result){
                var deleted = await _courseClassDateRepo.DeleteCourseClassDateAsync(cls);
                if(deleted == null){
                    return StatusCode(500);
                }
            }

            return NoContent();
        }
        [HttpDelete("University/Faculty/Department/Course/Class/Date/")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCourseClassDate([FromBody] CourseClassDateDeleteDto courseClassDateDeleteDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(courseClassDateDeleteDto == null){
                return BadRequest();
            }

            var classId = await _classDateRepo.GetClassDateIdAsync(courseClassDateDeleteDto.Day, courseClassDateDeleteDto.Time, courseClassDateDeleteDto.NumberOfClasses);
            
            if(classId == null){
                return NotFound("Class Date not found");
            }

            var courseClassDate = await _courseClassDateRepo.GetCourseClassDateAsync(courseClassDateDeleteDto.CourseCode, classId.Id);

            if(courseClassDate == null){
                return NotFound("Course is not given at that date.");
            }

            var result = await _courseClassDateRepo.DeleteCourseClassDateAsync(courseClassDate);

            if(result == null){
                return StatusCode(500);
            }

            return NoContent();
        }
    }
}