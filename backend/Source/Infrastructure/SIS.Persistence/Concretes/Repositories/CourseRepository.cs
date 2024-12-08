using Microsoft.EntityFrameworkCore;
using SIS.Application.Interfaces.Repositories;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Contexts.Data;

namespace SIS.Persistence.Concretes.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDBContext _context;
        public CourseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Course?> AddCourseAsync(Course course)
        {
            await _context.AddAsync(course);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return course;
        }
        public async Task<Course?> DeleteCourseAsync(string CourseName)
        {
            var course = await GetCourseAsync(CourseName);

            if (course == null)
            {
                return null;
            }

            _context.Remove(course);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return course;
        }
        public async Task<Course?> GetCourseAsync(string CourseName)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseName == CourseName);

            return course;
        }
        public async Task<Course?> GetCourseAsync(int CourseId)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == CourseId);

            return course;
        }
        public async Task<ICollection<Course>> GetCoursesAsync()
        {
            var courses = await _context.Courses.ToListAsync();

            return courses;
        }
        public async Task<Course?> UpdateCourseAsync(Course course)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return course;
        }
    }
}