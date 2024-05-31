using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using api.DTO.DeparmentCourse;
using api.DTO.DepartmentCourse;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DepartmentCourseController: ControllerBase
    {
        private readonly IDepartmentCourseRepository _departmentCourseRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseDetailsRepository _courseDetailsRepository;
        private readonly ISemesterDetailsRepository _semesterDetailsRepository;
        private readonly IStudentCourseDetailsRepository _studentDepDetailsRepository;
        private readonly IStudentCourseDetailsRepostiory _studentCourseDetailsRepostiory;
        private readonly ILecturerAccountRepository _lecturerAccountRepository;
        private readonly ICourseClassRepository _courseClassRepository; 
        private readonly IUniversityRepository _universityRepository;   
        public DepartmentCourseController(
            IDepartmentCourseRepository courseDepRepository, IDepartmentRepository departmentRepository, 
            ICourseRepository courseRepository, ICourseDetailsRepository courseDetailsRepository, 
            ISemesterDetailsRepository semesterDetailsRepository, IStudentCourseDetailsRepository studentDepDetailsRepository, 
            ILecturerAccountRepository lecturerAccountRepository, ICourseClassRepository courseClassRepository, 
            IUniversityRepository universityRepository, IStudentCourseDetailsRepostiory studentCourseDetailsRepostiory){
            _departmentCourseRepository = courseDepRepository;
            _departmentRepository = departmentRepository;
            _courseRepository = courseRepository;
            _courseDetailsRepository = courseDetailsRepository;
            _semesterDetailsRepository = semesterDetailsRepository;
            _studentDepDetailsRepository = studentDepDetailsRepository;
            _lecturerAccountRepository = lecturerAccountRepository;
            _courseClassRepository = courseClassRepository;
            _universityRepository = universityRepository;
            _studentCourseDetailsRepostiory = studentCourseDetailsRepostiory;
        }

        [HttpGet("University/Faculty/Department/Course/")]
        public async Task<IActionResult> GetDepCourseByCourseAndDepName([FromQuery] String DepName, [FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var course = await _departmentCourseRepository.GetDeparmentCourseAsync(CourseName, DepName);

            if(course == null){
                return NotFound();
            }

            return Ok(course.ToDepartmentCourseDto());
        }
        [HttpGet("University/Faculty/Department/Semester/Courses/")]
        public async Task<IActionResult> GetActiveDepCoursesBySemester([FromQuery] String DepName, [FromQuery] String Level,[FromQuery] int Semester){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var courses = await _departmentCourseRepository.GetDepartmentSemesterCoursesAsync(DepName, Level, Semester);

            if(courses == null){
                return NotFound();
            }

            return Ok(courses.ToDepartmentCourseDto());
        }
        [HttpGet("University/Faculty/Departments/Course")]
        public async Task<IActionResult> GetDepartmentsOfCourse([FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var courses = await _departmentCourseRepository.GetDepartmentsOfCourseByCourseNameAsync(CourseName);

            if(courses == null){
                return NotFound();
            }

            return Ok(courses.ToDepartmentCourseDto());
        }
        [HttpGet("University/Faculty/Department/Courses/")]
        public async Task<IActionResult> GetCoursesOfDepartment([FromQuery] String DepName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var courses = await _departmentCourseRepository.GetDepartmentCoursesAsync(DepName);

            if(courses == null){
                return NotFound();
            }

            return Ok(courses.ToDepartmentCourseDto());
        }
        [HttpPost("University/Faculty/Department/Course")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCourseToDepartment([FromBody] DepartmentCoursePostDto coursePostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var validDepartment = await _departmentRepository.GetDepartmentAsync(coursePostDto.DepartmentName);

            if(validDepartment == null){
                return NotFound("Department not found!");
            }

            var validCourse = await _courseRepository.GetCourseAsync(coursePostDto.CourseName);

            if(validCourse == null){
                return NotFound("Course not found!");
            }

            var courseDetails = await _courseDetailsRepository.GetCourseDetailsAsync(coursePostDto.CourseDetailsId);
            if(courseDetails == null){
                return NotFound("Course Details not found");
            } 

            if(courseDetails.CourseName != coursePostDto.CourseName){
                return BadRequest("Course Details and Course Name doesn't match.");
            }

            var SemesterDetail = await _semesterDetailsRepository.GetSemesterDetailsAsync(coursePostDto.DepartmentName, coursePostDto.TaughtSemester);
            if(SemesterDetail == null){
                return NotFound("Semester Details not found. Either that semester doesn't exist or its info is not posted yet.");
            }
            int academicYear = (coursePostDto.TaughtSemester + 1) / 2;
            int totalCourses = await _semesterDetailsRepository.GetNumOfCoursesInAcademicYear(academicYear);

            if(totalCourses == -1){
                return NotFound("No semester details on the specified academic year.");
            }
            int code = academicYear*1000 + totalCourses + 1;
            String CourseCode = validDepartment.DepCode + "-" + code.ToString();

            var depsDetails = await _departmentCourseRepository.AddCourseToDepAsync(coursePostDto.ToDepartmentCourse(CourseCode));
            
            if(depsDetails == null){
                return BadRequest();
            }
            
            SemesterDetail.TotalCourses++;
            var result = await _semesterDetailsRepository.UpdateSemesterDetailsAsync(SemesterDetail);

            if(result == null){
                return StatusCode(500, "Failed to increment semester courses.");
            }

            return Ok(depsDetails.ToDepartmentCourseDto());
        }
        [HttpPut("University/Faculty/Department/Course")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCourseOfDepartment([FromQuery] String DepName, [FromQuery] String CourseName, [FromBody] DepartmentCourseUpdateDto departmentCourseUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(departmentCourseUpdateDto.CourseName != CourseName || departmentCourseUpdateDto.DepartmentName != DepName){
                return BadRequest();
            }

            if(departmentCourseUpdateDto.Status != "Open" && departmentCourseUpdateDto.Status != "Closed"){
                return BadRequest("Status can only be Open or Closed");
            }

            var SemesterDetail = await _semesterDetailsRepository.GetSemesterDetailsAsync(departmentCourseUpdateDto.DepartmentName, departmentCourseUpdateDto.TaughtSemester);
            if(SemesterDetail == null){
                return NotFound("Semester Details not found. Either that semester doesn't exist or its info is not posted yet. Failed to Update the Course.");
            }

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(CourseName, DepName);

            if(depCourse == null){
                return BadRequest();
            }

            depCourse.TaughtSemester = departmentCourseUpdateDto.TaughtSemester;
            depCourse.Status = departmentCourseUpdateDto.Status;
            depCourse.CourseDetailsId = departmentCourseUpdateDto.CourseDetailsId;
            
            var updatedDepCourse = await _departmentCourseRepository.UpdateDepsCourseAsync(depCourse);
            
            if(updatedDepCourse == null){
                return StatusCode(500);
            }

            return Ok(updatedDepCourse.ToDepartmentCourseDto());
        }
        [HttpDelete("University/Faculty/Deparment/Course")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCourseOfDepartment([FromQuery] String DepName, [FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(CourseName, DepName);

            if(validCourse == null){
                return NotFound();
            }
            
            var SemesterDetail = await _semesterDetailsRepository.GetSemesterDetailsAsync(validCourse.DepartmentName, validCourse.TaughtSemester);
            if(SemesterDetail == null){
                return NotFound("Semester Details not found. Either that semester doesn't exist or its info is not posted yet. Failed to Delete the Course.");
            }
            // Should not decrese because CourseCode depends on it 
            /*
            SemesterDetail.TotalCourses--;
            var result = await _semesterDetailsRepository.UpdateSemesterDetailsAsync(SemesterDetail);

            if(result == null){
                return StatusCode(500, "Failed to decrease semester courses. Aborting course deletion.");
            }
            */

            var deletionResult = await _departmentCourseRepository.DeleteCourseFromDepAsync(CourseName, DepName);

            if(deletionResult == null){
                return BadRequest();
            }

            return NoContent();
        }
        [HttpGet("University/Faculty/Department/Semester/Student/Courses/")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetAvailableCourseSelection([FromQuery] String DepName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validDepartment = await _departmentRepository.GetDepartmentAsync(DepName);

            if(validDepartment == null){
                return NotFound("Department not found!");
            }

            TimeSpan start = TimeSpan.FromTicks(validDepartment.CourseSelectionStartDate.Ticks);
            TimeSpan current = TimeSpan.FromTicks(DateTime.Now.Ticks);
            TimeSpan end = TimeSpan.FromTicks(validDepartment.CourseSelectionEndDate.Ticks);

            if(current < start || current > end){
                return BadRequest("Course Selection is closed.");
            }

            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            var depsDetails = await _studentDepDetailsRepository.GetStudentDepDetailAsync(TC, DepName);

            if(depsDetails == null){
                return NotFound("You're not registered on this course");
            }

            CoursesSelectionDto list = await GetAvailableCourseSelectionList(depsDetails);

            return Ok(list);
        }

        private async Task<CoursesSelectionDto> GetAvailableCourseSelectionList(StudentDepDetails depDetails){
            CoursesSelectionDto list = new()
            {
                PassedCourses = await GetCoursesOfStudent("Passed", depDetails.DepartmentName, depDetails.TC, depDetails.CurrentSemester % 2),
                FailedCourses = await GetCoursesOfStudent("Failed", depDetails.DepartmentName, depDetails.TC, depDetails.CurrentSemester % 2),
                PartiallyPassedCourses = await GetCoursesOfStudent("Partially Passed", depDetails.DepartmentName, depDetails.TC, depDetails.CurrentSemester % 2)
            };

            if (depDetails.Gno != null && depDetails.Gno < 1.8 && depDetails.CurrentSemester > 4){
                return list;
            }

            list.CurrentSemesterCourses = await GetSemesterSelectionCourses(0, depDetails.DepartmentName, depDetails.StudentType, depDetails.CurrentSemester);

            if(depDetails.Gno > 3.0 && list.FailedCourses == null){
                list.OverHeadCourses =  await GetSemesterSelectionCourses(1, depDetails.DepartmentName, depDetails.StudentType, depDetails.CurrentSemester);
            }
            
            return list;
        }
        private async Task<ICollection<CourseSelectionDto>?> GetSemesterSelectionCourses(int type, String DepName, String StudentType, int Semester){
            var dep = await _departmentRepository.GetDepartmentAsync(DepName);
            if(dep == null){
                return null;
            }

            ICollection<DepartmentCourse>? courses = null;
            if(type == 0)
                courses = await _departmentCourseRepository.GetDepartmentSemesterCoursesAsync(DepName, StudentType, Semester);
            else
                courses = await _departmentCourseRepository.GetOverHeadDepCourses(DepName, StudentType, Semester);
            
            if(courses == null){
                return null;
            }
            
            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            if(uni == null){
                return null;
            }

            ICollection<CourseSelectionDto> courseSelectionList = [];
            foreach(var course in courses){
                var cc = await _courseClassRepository.GetCourseClassAsync(course.CourseCode, uni.CurrentSchoolYear);
                var lec = await _lecturerAccountRepository.GetLecturerAccountByTCAsync(cc.LecturerTC);
                var cd = await _courseDetailsRepository.GetCourseDetailsAsync(course.CourseDetailsId);
                var courseSelectionDto = new CourseSelectionDto{
                    CourseName = course.CourseName,
                    CourseCode = course.CourseCode,
                    CourseType = cd.CourseType,
                    AKTS = cc.AKTS,
                    Kredi = cc.Kredi,
                    LecturerName = lec.FirstName + lec.LastName
                };
                courseSelectionList.Add(courseSelectionDto);
            }

            return courseSelectionList;
        }
        private async Task<ICollection<CourseSelectionDto>?> GetCoursesOfStudent(String Type, String DepName, String TC, int semType){
            if(Type == null){
                return null;
            }
            ICollection<StudentCourseDetails>? coursesDetails = null;
            if(Type == "Failed"){
                coursesDetails = await _studentCourseDetailsRepostiory.GetFailedCoursesAsync(DepName, TC, semType);
            }else if(Type == "Passed")
                coursesDetails = await _studentCourseDetailsRepostiory.GetPassedCoursesAsync(DepName, TC, semType);
            else if(Type == "Partially Passed")
                coursesDetails = await _studentCourseDetailsRepostiory.GetPartiallyPassedCoursesAsync(DepName, TC, semType);
            else
                return null;

            if(coursesDetails == null)
                return null;

            var uni = await _universityRepository.GetUniversityByIdAsync(1);
            if(uni == null){
                return null;
            }

            ICollection<DepartmentCourse> courses = [];

            foreach(var courseDetail in coursesDetails){
                var course = await _departmentCourseRepository.GetDeparmentCourseByCourseCodeAsync(courseDetail.CourseCode);
                courses.Add(course);
            }

            if(courses == null){
                return null;
            }

            ICollection<CourseSelectionDto> courseSelectionList = [];
            foreach(var course in courses){
                var cc = await _courseClassRepository.GetCourseClassAsync(course.CourseCode, uni.CurrentSchoolYear);
                var lec = await _lecturerAccountRepository.GetLecturerAccountByTCAsync(cc.LecturerTC);
                var cd = await _courseDetailsRepository.GetCourseDetailsAsync(course.CourseDetailsId);
                var courseSelectionDto = new CourseSelectionDto{
                    CourseName = course.CourseName,
                    CourseCode = course.CourseCode,
                    CourseType = cd.CourseType,
                    AKTS = cc.AKTS,
                    Kredi = cc.Kredi,
                    LecturerName = lec.FirstName + lec.LastName
                };
                courseSelectionList.Add(courseSelectionDto);
            }

            return courseSelectionList;
        }
    }
}