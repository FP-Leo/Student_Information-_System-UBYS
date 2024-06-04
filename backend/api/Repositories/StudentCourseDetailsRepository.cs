using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StudentCourseDetailsRepository : IStudentCourseDetailsRepostiory
    {
        private readonly ApplicationDBContext _context;

        public StudentCourseDetailsRepository(ApplicationDBContext context){
            _context = context;
        }
        public async Task<StudentCourseDetails?> DeleteStudentCourseDetailsAsync(String CourseCode, String TC, int SchoolYear)
        {
            var studentCourseDetail = await GetStudentCourseDetails(CourseCode, TC, SchoolYear);

            if (studentCourseDetail == null){
                return null;
            }

            _context.Remove(studentCourseDetail);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return studentCourseDetail;
        }

        public async Task<ICollection<StudentCourseDetails>?> GetAllStudentsCourseDetails(String CourseCode, int SchoolYear)
        {
            var studentsCourseDetails = await _context.StudentsCourseDetails.Where(dd=> dd.CourseCode == CourseCode && dd.SchoolYear == SchoolYear).ToListAsync();  

            return studentsCourseDetails;
        }

        public async Task<StudentCourseDetails?> GetStudentCourseDetails(string CourseCode, string TC, int SchoolYear)
        {
            var studentCourseDetails = await _context.StudentsCourseDetails.FirstOrDefaultAsync(dd=> dd.CourseCode == CourseCode && dd.TC == TC && dd.SchoolYear == SchoolYear);

            return studentCourseDetails;
        }

        public async Task<ICollection<StudentCourseDetails>?> GetStudentsAllCourseDetails(string? Department, string? TC)
        {
            var studentCoursesDetails = await _context.StudentsCourseDetails.Where(dd=> dd.DepartmentName == Department &&  dd.TC == TC).ToListAsync();

            return studentCoursesDetails;
        }

        public async Task<StudentCourseDetails?> CreateStudentCourseDetails(StudentCourseDetails studentCourseDetails)
        {
            await _context.AddAsync(studentCourseDetails);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return studentCourseDetails;
        }

        public async Task<StudentCourseDetails?> UpdateStudentCourseDetailsAsync(StudentCourseDetails studentCourseDetails)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return studentCourseDetails;
        }

        public async Task<ICollection<StudentCourseDetails>?> GetFailedCoursesAsync(string DepName, string TC, int semType)
        {
            var studentCoursesDetails = await _context.StudentsCourseDetails.Where(dd=> dd.DepartmentName == DepName &&  dd.TC == TC && dd.State == "Failed" && dd.CourseClass.DepartmentCourse.TaughtSemester % 2 == semType).ToListAsync();

            return studentCoursesDetails;
        }

        public async Task<ICollection<StudentCourseDetails>?> GetPassedCoursesAsync(string DepName, string TC, int semType)
        {
            var studentCoursesDetails = await _context.StudentsCourseDetails.Where(dd=> dd.DepartmentName == DepName &&  dd.TC == TC && dd.State == "Passed" && dd.CourseClass.DepartmentCourse.TaughtSemester % 2 == semType).ToListAsync();

            return studentCoursesDetails;
        }

        public async Task<ICollection<StudentCourseDetails>?> GetPartiallyPassedCoursesAsync(string DepName, string TC, int semType)
        {
            var studentCoursesDetails = await _context.StudentsCourseDetails.Where(dd=> dd.DepartmentName == DepName &&  dd.TC == TC && dd.State == "Partially Passed" && dd.CourseClass.DepartmentCourse.TaughtSemester % 2 == semType).ToListAsync();

            return studentCoursesDetails;
        }

        public async Task<ICollection<StudentCourseDetails>?> GetActiveCoursesAsync(string DepName, string TC)
        {
            var studentCoursesDetails = await _context.StudentsCourseDetails.Where(dd=> dd.DepartmentName == DepName &&  dd.TC == TC && dd.State == "Attending").ToListAsync();

            return studentCoursesDetails;
        }

        public async Task<ICollection<StudentCourseDetails>?> GetStudentCourseDetails(string CourseCode, string TC)
        {
            var studentCourseDetails = await _context.StudentsCourseDetails.Where(dd=> dd.CourseCode == CourseCode && dd.TC == TC).ToListAsync();

            return studentCourseDetails;
        }
    }
}