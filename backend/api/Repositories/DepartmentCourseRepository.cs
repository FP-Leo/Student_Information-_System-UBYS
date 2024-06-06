using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class DepartmentCourseRepository : IDepartmentCourseRepository
    {
        private readonly ApplicationDBContext _context;
        public DepartmentCourseRepository(ApplicationDBContext context){
            _context = context;
        }
        
        public async Task<DepartmentCourse?> AddCourseToDepAsync(DepartmentCourse course)
        {
            await _context.AddAsync(course);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return course;
        }
        public async Task<DepartmentCourse?> DeleteCourseFromDepAsync(String CourseName, String DepartmentName)
        {
            var course = await GetDeparmentCourseAsync(CourseName, DepartmentName);

            if (course == null){
                return null;
            }

            _context.Remove(course);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return course;
        }
        public async Task<ICollection<DepartmentCourse>?> GetDepartmentsOfCourseByCourseNameAsync(String CourseName)
        {
            var courses = await _context.DepartmentCourses.Where(c=> c.CourseName == CourseName).ToListAsync();

            return courses;
        }
        public async Task<DepartmentCourse?> GetDeparmentCourseAsync(String CourseName, String DepartmentName)
        {
            var course = await _context.DepartmentCourses.FirstOrDefaultAsync(c=> c.CourseName == CourseName && c.DepartmentName == DepartmentName);

            return course;
        }
        public async Task<ICollection<DepartmentCourse>?> GetDepartmentCoursesAsync(String DepartmentName)
        {
            var courses = await _context.DepartmentCourses.Where(c=> c.DepartmentName == DepartmentName).ToListAsync();

            return courses;
        }
        public async Task<DepartmentCourse?> UpdateDepsCourseAsync(DepartmentCourse course)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return course;
        }

        public async Task<ICollection<DepartmentCourse>?> GetDepartmentSemesterCoursesAsync(String DepartmentName, String Level, int Semester)
        {
            var courses = await _context.DepartmentCourses.Where(c=> c.DepartmentName == DepartmentName && c.TaughtSemester == Semester && c.Status == "Open" && c.CourseDetails.CourseLevel == Level).ToListAsync();

            return courses;
        }

        public async Task<DepartmentCourse?> GetDeparmentCourseByCourseCodeAsync(string CourseCode)
        {
            var course = await _context.DepartmentCourses.FirstOrDefaultAsync(c=> c.CourseCode == CourseCode);

            return course;
        }

        public async Task<ICollection<DepartmentCourse>?> GetDepartmentSemesterCoursesRangeAsync(string DepartmentName, string Type, int lowerBound, int upperBound)
        {
            if(lowerBound < 0 || upperBound > 8)
                return null;
            var courses = await _context.DepartmentCourses.Where(c=> c.DepartmentName == DepartmentName && c.CourseDetails.CourseType == Type && c.TaughtSemester > lowerBound && c.TaughtSemester <= upperBound).ToListAsync();

            return courses;
        }

        public async Task<ICollection<DepartmentCourse>?> GetOverHeadDepCourses(string DepartmentName, string Type, int semester)
        {
            if(semester < 0 || semester > 8)
                return null;
            var courses = await _context.DepartmentCourses.Where(c=> c.DepartmentName == DepartmentName && c.CourseDetails.CourseType == Type && c.TaughtSemester > semester && c.TaughtSemester % 2 == semester % 2).ToListAsync();

            return courses;
        }

        public async Task<ICollection<DepartmentCourse>?> GetActiveCourses()
        {
            var courses = await _context.DepartmentCourses.Where(c => c.Status == "Open").ToListAsync();

            return courses;
        }
    }
}