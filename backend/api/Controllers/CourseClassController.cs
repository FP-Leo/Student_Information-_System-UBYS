
using api.DTO.CourseClass;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CourseClassController : ControllerBase
    {
        private readonly ICourseClassRepository _courseClassRepository;
        private readonly IDepartmentCourseRepository _departmentCourseRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUniversityRepository _universityRepository;
        private readonly ILecturerDepDetailsRepository _lecturerDepDetailsRepository;
        public CourseClassController(ICourseClassRepository courseClassRepository, IDepartmentCourseRepository departmentCourseRepository, IDepartmentRepository departmentRepository, IUniversityRepository universityRepository, ILecturerDepDetailsRepository lecturerDepDetailsRepository){
            _courseClassRepository = courseClassRepository;
            _departmentCourseRepository = departmentCourseRepository;
            _departmentRepository = departmentRepository;
            _universityRepository = universityRepository;
            _lecturerDepDetailsRepository = lecturerDepDetailsRepository;
        }
        [HttpGet("University/Faculty/Department/Course/Class")]
        public async Task<IActionResult> GetCurrentCourseClass([FromQuery] String DepName, [FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(CourseName, DepName);

            if(depCourse == null){
                return NotFound();
            }

            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);

            var courseClass = await _courseClassRepository.GetCourseClassAsync(DepName, CourseName, uni.CurrentSchoolYear);
            
            if(courseClass == null){
                return NotFound();
            }

            return Ok(courseClass.ToCourseClassDto());
        }
        [HttpGet("University/Faculty/Department/Course/Class/{SchoolYear:int}")]
        public async Task<IActionResult> GetCourseClass(int SchoolYear, [FromQuery] String DepName, [FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(CourseName, DepName);

            if(depCourse == null){
                return NotFound();
            }

            var courseClass = await _courseClassRepository.GetCourseClassAsync(DepName, CourseName, SchoolYear);
            
            if(courseClass == null){
                return NotFound();
            }

            return Ok(courseClass.ToCourseClassDto());
        }
        [HttpGet("University/Faculty/Department/Courses/Class")]
        public async Task<IActionResult> GetCurrentCoursesClass([FromQuery] String DepName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var dep = await _departmentRepository.GetDepartmentAsync(DepName);

            if(dep == null){
                return NotFound();
            }
            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);

            var coursesClass = await _courseClassRepository.GetSpecificCourseClasses(DepName, uni.CurrentSchoolYear);
            
            if(coursesClass == null){
                return NotFound();
            }

            return Ok(coursesClass);
        }
        [HttpPost("University/Faculty/Department/Course/Class")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCourseClass([FromBody] CourseClassPostDto courseClassPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(courseClassPostDto.CourseName, courseClassPostDto.DepartmentName);

            if(depCourse == null){
                return NotFound();
            }

            var lectDepDetails = await _lecturerDepDetailsRepository.GetLecturerDepsDetailsAsync(courseClassPostDto.LecturerTC);

            if(lectDepDetails == null){
                return BadRequest("The lecturer is currently not registered at this department.");
            }
            /*
            if(courseDetails.CourseType == "Zorunlu"){
                var courses = await _departmentCourseRepository.GetDepartmentSemesterCoursesAsync(coursePostDto.DepartmentName, coursePostDto.TaughtSemester);
                //var classes = await _courseClassRepository.Get
                int totalAKTS = 0;
                foreach(var course in courses){
                    //totalAKTS += course.A;
                }
            }else{
                // Check if AKTS are the same as Secmeli AKTS
            }*/

            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            
            var courseClass = await _courseClassRepository.AddCourseClassAsync(courseClassPostDto.ToCourseClass(uni.CurrentSchoolYear));
            
            if(courseClass == null){
                return BadRequest();
            }

            return Ok(courseClass.ToCourseClassDto());
        }
        [HttpPut("University/Faculty/Department/Course/Class")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCourseClass([FromQuery] String DepName, [FromQuery] String CourseName, [FromBody] CourseClassUpdateDto courseClassUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(DepName != courseClassUpdateDto.DepartmentName || CourseName != courseClassUpdateDto.CourseName){
                return BadRequest(ModelState);
            }

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(courseClassUpdateDto.CourseName, courseClassUpdateDto.DepartmentName);

            if(depCourse == null){
                return NotFound();
            }

            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);

            var courseClass = await _courseClassRepository.GetCourseClassAsync(DepName, CourseName, uni.CurrentSchoolYear);
            
            if(courseClass == null){
                return NotFound();
            }

            courseClass.HourPerWeek = courseClassUpdateDto.HourPerWeek;
            courseClass.AKTS = courseClassUpdateDto.AKTS;
            courseClass.Kredi = courseClassUpdateDto.Kredi;
            courseClass.MidTermValue = courseClassUpdateDto.MidTermValue;
            courseClass.FinalValue = courseClassUpdateDto.FinalValue;
            
            var updatedCourseClass = await _courseClassRepository.UpdateCourseClassAsync(courseClass);
            
            if(updatedCourseClass == null){
                return StatusCode(500);
            }

            return Ok(updatedCourseClass.ToCourseClassDto());
        }
        [HttpPut("University/Faculty/Department/Course/Class/Lecturer")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateCourseClassLecturer([FromQuery] String DepName, [FromQuery] String CourseName, [FromBody] CourseClassUpdateLecturerDto courseClassUpdateLecturerDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(DepName != courseClassUpdateLecturerDto.DepartmentName || CourseName != courseClassUpdateLecturerDto.CourseName){
                return BadRequest(ModelState);
            }

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(courseClassUpdateLecturerDto.CourseName, courseClassUpdateLecturerDto.DepartmentName);

            if(depCourse == null){
                return NotFound();
            }

            var lectDepDetails = await _lecturerDepDetailsRepository.GetLecturerDepsDetailsAsync(courseClassUpdateLecturerDto.LecturerTC);

            if(lectDepDetails == null){
                return BadRequest("The lecturer is currently not registered at this department.");
            }

            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);

            var courseClass = await _courseClassRepository.GetCourseClassAsync(DepName, CourseName, uni.CurrentSchoolYear);
            
            if(courseClass == null){
                return NotFound();
            }
            
            courseClass.LecturerTC = courseClassUpdateLecturerDto.LecturerTC;
            
            var updatedCourseClass = await _courseClassRepository.UpdateCourseClassAsync(courseClass);
            
            if(updatedCourseClass == null){
                return StatusCode(500);
            }

            return Ok(updatedCourseClass.ToCourseClassDto());
        }
        [HttpDelete("University/Faculty/Department/Course/Class")]
        public async Task<IActionResult> DeleteCourseClass([FromQuery] String DepName, [FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(CourseName, DepName);

            if(depCourse == null){
                return NotFound();
            }

            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);

            var result = await _courseClassRepository.DeleteCourseClassAsync(DepName, CourseName, uni.CurrentSchoolYear);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
    }
}