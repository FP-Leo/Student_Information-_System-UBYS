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
        public async Task<ICollection<DepartmentCourse>> GetDepartmentsOfCourseByCourseNameAsync(String CourseName)
        {
            var courses = await _context.DepartmentCourses.Where(c=> c.CourseName == CourseName).ToListAsync();

            return courses;
        }
        public async Task<DepartmentCourse?> GetDeparmentCourseAsync(String CourseName, String DepartmentName)
        {
            var course = await _context.DepartmentCourses.FirstOrDefaultAsync(c=> c.CourseName == CourseName && c.DepartmentName == DepartmentName);

            return course;
        }
        public async Task<ICollection<DepartmentCourse>> GetDepartmentCoursesAsync(String DepartmentName)
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

        public async Task<ICollection<DepartmentCourse>> GetDepartmentSemesterCoursesAsync(string DepartmentName, int Semester)
        {
            var courses = await _context.DepartmentCourses.Where(c=> c.DepartmentName == DepartmentName && c.TaughtSemester == Semester && c.Status == "Open").ToListAsync();

            return courses;
        }
    }
}