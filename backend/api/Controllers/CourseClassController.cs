
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
        private readonly ICourseDetailsRepository _courseDetailsRepository;
        private readonly ISemesterDetailsRepository _semesterDetailsRepository;
        public CourseClassController(ICourseClassRepository courseClassRepository, IDepartmentCourseRepository departmentCourseRepository, IDepartmentRepository departmentRepository, IUniversityRepository universityRepository, ILecturerDepDetailsRepository lecturerDepDetailsRepository, ICourseDetailsRepository courseDetailsRepository, ISemesterDetailsRepository semesterDetailsRepository){
            _courseClassRepository = courseClassRepository;
            _departmentCourseRepository = departmentCourseRepository;
            _departmentRepository = departmentRepository;
            _universityRepository = universityRepository;
            _lecturerDepDetailsRepository = lecturerDepDetailsRepository;
            _courseDetailsRepository = courseDetailsRepository;
            _semesterDetailsRepository = semesterDetailsRepository;
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

            var courseClass = await _courseClassRepository.GetCourseClassAsync(depCourse.CourseCode, uni.CurrentSchoolYear);
            
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

            var courseClass = await _courseClassRepository.GetCourseClassAsync(depCourse.CourseCode, SchoolYear);
            
            if(courseClass == null){
                return NotFound();
            }

            return Ok(courseClass.ToCourseClassDto());
        }
        /*
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
        */
        [HttpPost("University/Faculty/Department/Course/Class")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCourseClass([FromQuery] String DepName, [FromQuery] String CourseName, [FromBody] CourseClassPostDto courseClassPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(CourseName, DepName);

            if(depCourse == null){
                return NotFound();
            }

            if(depCourse.CourseCode != courseClassPostDto.CourseCode){
                return BadRequest(ModelState);
            }

            var lectDepDetails = await _lecturerDepDetailsRepository.GetLecturerDepsDetailsAsync(courseClassPostDto.LecturerTC);

            if(lectDepDetails == null){
                return BadRequest("The lecturer is currently not registered at this department.");
            }

            var courseDetails = await _courseDetailsRepository.GetCourseDetailsAsync(depCourse.CourseDetailsId);
            
            if(courseDetails == null){
                return StatusCode(500, "Couldn't get the course details.");
            }
            
            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);

            if(uni == null){
                return StatusCode(500, "Coudn't get university data.");
            }

            var SemesterDetail = await _semesterDetailsRepository.GetSemesterDetailsAsync(depCourse.DepartmentName, depCourse.TaughtSemester);
            if(SemesterDetail == null){
                return StatusCode(500, "Coudn't get university data.");
            }

            if(courseDetails.CourseType == "Mandatory"){
                var courses = await _departmentCourseRepository.GetDepartmentSemesterCoursesAsync(depCourse.DepartmentName, depCourse.TaughtSemester);
                int totalAKTS = 0;
                foreach(var course in courses){
                    var cd = await _courseDetailsRepository.GetCourseDetailsAsync(course.CourseDetailsId);
                    if(cd.CourseType == "Mandatory"){
                        var cc = await _courseClassRepository.GetCourseClassAsync(course.CourseCode, uni.CurrentSchoolYear);
                        totalAKTS += cc.AKTS;
                    }
                    var totalAKTSwS = totalAKTS + SemesterDetail.SelectiveCourseACTS*SemesterDetail.NumberOfSelectiveCourses;
                    if(totalAKTSwS == 30)
                        return BadRequest("AKTS for this Semester are full. To add a new course change the other courses' AKTS or remove one of them.");
                    if(totalAKTSwS + courseClassPostDto.AKTS > 30)
                        return BadRequest("Opening this course exceeds 30 ATKS. Either remove another course or change AKTSs so that it is 30.");
                }
            }else{
                if(courseClassPostDto.AKTS != SemesterDetail.SelectiveCourseACTS){
                    return BadRequest("AKTS of Selective Courses must be the same as the others on the semester");
                }
            }

            var courseClass = await _courseClassRepository.AddCourseClassAsync(courseClassPostDto.ToCourseClass(uni.CurrentSchoolYear));
            
            if(courseClass == null){
                return BadRequest();
            }

            depCourse.Status = "Open";
            var res = await _departmentCourseRepository.UpdateDepsCourseAsync(depCourse);

            if(res == null){
                return StatusCode(500, "Failed to set Course as Open.");
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

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(CourseName, DepName);

            if(depCourse == null){
                return NotFound();
            }

            if(depCourse.CourseCode != courseClassUpdateDto.CourseCode){
                return BadRequest();
            }

            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);

            var courseClass = await _courseClassRepository.GetCourseClassAsync(depCourse.CourseCode, uni.CurrentSchoolYear);
            
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

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(CourseName, DepName);

            if(depCourse == null){
                return NotFound();
            }

            if(depCourse.CourseCode != courseClassUpdateLecturerDto.CourseCode){
                return BadRequest("");
            }

            var lectDepDetails = await _lecturerDepDetailsRepository.GetLecturerDepsDetailsAsync(courseClassUpdateLecturerDto.LecturerTC);

            if(lectDepDetails == null){
                return BadRequest("The lecturer is currently not registered at this department.");
            }

            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);

            var courseClass = await _courseClassRepository.GetCourseClassAsync(depCourse.CourseCode, uni.CurrentSchoolYear);
            
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

            var result = await _courseClassRepository.DeleteCourseClassAsync(depCourse.CourseCode, uni.CurrentSchoolYear);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
        [HttpGet("University/Faculty/Department/Course/Class/Code")]
        public async Task<IActionResult> GetCurrentCourseClassByCode([FromQuery] String CourseCode){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var depCourse = await _departmentCourseRepository.GetDeparmentCourseByCourseCodeAsync(CourseCode);

            if(depCourse == null){
                return NotFound();
            }

            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);

            var courseClass = await _courseClassRepository.GetCourseClassAsync(CourseCode, uni.CurrentSchoolYear);
            
            if(courseClass == null){
                return NotFound();
            }

            return Ok(courseClass.ToCourseClassDto());
        }
        [HttpGet("University/Faculty/Department/Course/Class/Code/{SchoolYear:int}")]
        public async Task<IActionResult> GetCourseClassByCode(int SchoolYear, [FromQuery] String CourseCode){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var depCourse = await _departmentCourseRepository.GetDeparmentCourseByCourseCodeAsync(CourseCode);

            if(depCourse == null){
                return NotFound();
            }

            var courseClass = await _courseClassRepository.GetCourseClassAsync(CourseCode, SchoolYear);
            
            if(courseClass == null){
                return NotFound();
            }

            return Ok(courseClass.ToCourseClassDto());
        }
        [HttpPost("University/Faculty/Department/Course/Class/Code")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCourseClassByCode([FromBody] CourseClassPostDto courseClassPostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseByCourseCodeAsync(courseClassPostDto.CourseCode);

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
        [HttpPut("University/Faculty/Department/Course/Class/Code")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCourseClassByCode([FromQuery] String CourseCode, [FromBody] CourseClassUpdateDto courseClassUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(CourseCode != courseClassUpdateDto.CourseCode){
                return BadRequest(ModelState);
            }

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseByCourseCodeAsync(CourseCode);

            if(depCourse == null){
                return NotFound();
            }

            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);

            var courseClass = await _courseClassRepository.GetCourseClassAsync(CourseCode, uni.CurrentSchoolYear);
            
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
        [HttpPut("University/Faculty/Department/Course/Class/Code/Lecturer")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateCourseClassLecturerByCode([FromQuery] String CourseCode, [FromBody] CourseClassUpdateLecturerDto courseClassUpdateLecturerDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(CourseCode != courseClassUpdateLecturerDto.CourseCode){
                return BadRequest(ModelState);
            }

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseByCourseCodeAsync(courseClassUpdateLecturerDto.CourseCode);

            if(depCourse == null){
                return NotFound();
            }

            var lectDepDetails = await _lecturerDepDetailsRepository.GetLecturerDepsDetailsAsync(courseClassUpdateLecturerDto.LecturerTC);

            if(lectDepDetails == null){
                return BadRequest("The lecturer is currently not registered at this department.");
            }

            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);

            var courseClass = await _courseClassRepository.GetCourseClassAsync(CourseCode, uni.CurrentSchoolYear);
            
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
        [HttpDelete("University/Faculty/Department/Course/Class/Code")]
        public async Task<IActionResult> DeleteCourseClassByCode([FromQuery] String CourseCode){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var depCourse = await _departmentCourseRepository.GetDeparmentCourseByCourseCodeAsync(CourseCode);

            if(depCourse == null){
                return NotFound();
            }

            // Since the system is for one University only I decided to hard code this instead of losing time. It is not good practice tho :)
            var uni = await _universityRepository.GetUniversityByIdAsync(1);

            var result = await _courseClassRepository.DeleteCourseClassAsync(CourseCode, uni.CurrentSchoolYear);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
    }
}