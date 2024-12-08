using Microsoft.EntityFrameworkCore;
using SIS.Application.Interfaces.Repositories;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Contexts.Data;

namespace SIS.Persistence.Concretes.Repositories
{
    public class CourseClassRepository : ICourseClassRepository
    {
        private readonly ApplicationDBContext _context;

        public CourseClassRepository(ApplicationDBContext context)
        {
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

        public async Task<CourseClass?> DeleteCourseClassAsync(string CourseCode, int SchoolYear)
        {
            var courseClass = await GetCourseClassAsync(CourseCode, SchoolYear);

            if (courseClass == null)
            {
                return null;
            }

            _context.Remove(courseClass);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return courseClass;
        }

        public async Task<CourseClass?> GetCourseClassAsync(string CourseCode, int SchoolYear)
        {
            var courseClass = await _context.CourseClasses.FirstOrDefaultAsync(cc => cc.CourseCode == CourseCode && cc.SchoolYear == SchoolYear);

            return courseClass;
        }

        public async Task<ICollection<CourseClass>?> GetLecturersClasses(string TC, int SchoolYear)
        {
            var courseClass = await _context.CourseClasses.Where(cc => cc.LecturerTC == TC && cc.SchoolYear == SchoolYear).ToListAsync();

            return courseClass;
        }

        public async Task<ICollection<CourseClass>?> GetLecturersDepClasses(string DepartmentName, string TC, int SchoolYear)
        {
            var courseClass = await _context.CourseClasses.Where(cc => cc.DepartmentCourse.DepartmentName == DepartmentName && cc.LecturerTC == TC && cc.SchoolYear == SchoolYear).ToListAsync();

            return courseClass;
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