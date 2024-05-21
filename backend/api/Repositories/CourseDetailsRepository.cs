using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CourseDetailsRepository : ICourseDetailsRepository
    {
        private readonly ApplicationDBContext _context;

        public CourseDetailsRepository(ApplicationDBContext context){
            _context = context;
        }

        public async Task<CourseDetails?> AddCourseDetailsAsync(CourseDetails courseExplanation)
        {
            await _context.AddAsync(courseExplanation);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return courseExplanation;
        }

        public async Task<CourseDetails?> DeleteCourseDetailsAsync(string DepartmentName, string CourseName)
        {
            var courseExplanation = await GetCourseDetailsAsync(DepartmentName, CourseName);

            if (courseExplanation == null){
                return null;
            }

            _context.Remove(courseExplanation);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return courseExplanation;
        }
        public async Task<CourseDetails?> GetCourseDetailsAsync(string DepartmentName, string CourseName)
        {
            var courseExplanation = await _context.CourseExplanations.FirstOrDefaultAsync(ce => ce.CourseName == CourseName && ce.DepartmentName == DepartmentName);

            return courseExplanation;
        }

        public async Task<CourseDetails?> UpdateCourseDetailsAsync(CourseDetails courseExplanation)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return courseExplanation;
        }
    }
}