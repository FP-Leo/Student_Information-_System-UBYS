using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CourseClassRepository : ICourseClassRepository
    {
        private readonly ApplicationDBContext _context;

        public CourseClassRepository(ApplicationDBContext context){
            _context = context;
        }
        public async Task<CourseClass?> AddCourseClassAsync(CourseClass courseClass)
        {
            await _context.AddAsync(courseClass);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return courseClass;
        }

        public async Task<CourseClass?> DeleteCourseClassAsync(string DepartmentName, string CourseName, int SchoolYear)
        {
            var courseClass = await GetCourseClassAsync(DepartmentName, CourseName, SchoolYear);

            if (courseClass == null){
                return null;
            }

            _context.Remove(courseClass);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return courseClass;
        }

        public async Task<CourseClass?> GetCourseClassAsync(string DepartmentName, string CourseName, int SchoolYear)
        {
            var courseClass = await _context.CourseClasses.FirstOrDefaultAsync(cc => cc.DepartmentName == DepartmentName && cc.CourseName == CourseName && cc.SchoolYear == SchoolYear);

            return courseClass;
        }

        public async Task<ICollection<CourseClass>?> GetSpecificCourseClasses(string DepartmentName, int SchoolYear)
        {
            var coursesClass = await _context.CourseClasses.Where(cc => cc.DepartmentName == DepartmentName && cc.SchoolYear == SchoolYear).ToListAsync();

            return coursesClass;
        }

        public async Task<CourseClass?> UpdateCourseClassAsync(CourseClass courseClass)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return courseClass;
        }
    }
}