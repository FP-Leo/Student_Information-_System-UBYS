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
        public async Task<StudentCourseDetails?> DeleteStudentCourseDetails(string? Department, string? Course, string? TC)
        {
            var studentCourseDetail = await GetStudentCourseDetails(Department, Course, TC);

            if (studentCourseDetail == null){
                return null;
            }

            _context.Remove(studentCourseDetail);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return studentCourseDetail;
        }

        public async Task<ICollection<StudentCourseDetails>?> GetAllStudentsCourseDetails(string? Department, string? Course)
        {
            var studentsCourseDetails = await _context.StudentsCourseDetails.Where(dd=> dd.DepartmentName == Department && dd.CourseName == Course).ToListAsync();

            return studentsCourseDetails;
        }

        public async Task<StudentCourseDetails?> GetStudentCourseDetails(string? Department, string? Course, string? TC)
        {
            var studentCourseDetails = await _context.StudentsCourseDetails.FirstOrDefaultAsync(dd=> dd.DepartmentName == Department && dd.CourseName == Course && dd.TC == TC);

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

        public async Task<StudentCourseDetails?> UpdateStudentCourseDetails(StudentCourseDetails studentCourseDetails)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return studentCourseDetails;
        }
    }
}