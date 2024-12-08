using Microsoft.EntityFrameworkCore;
using SIS.Application.Interfaces.Repositories;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Contexts.Data;

namespace SIS.Persistence.Concretes.Repositories
{
    public class CourseDetailsRepository : ICourseDetailsRepository
    {
        private readonly ApplicationDBContext _context;

        public CourseDetailsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<CourseDetails?> AddCourseDetailsAsync(CourseDetails courseDetails)
        {
            await _context.AddAsync(courseDetails);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return courseDetails;
        }

        public async Task<CourseDetails?> DeleteCourseDetailsAsync(int CourseDetailsId)
        {
            var courseDetails = await GetCourseDetailsAsync(CourseDetailsId);

            if (courseDetails == null)
            {
                return null;
            }

            _context.Remove(courseDetails);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return courseDetails;
        }
        public async Task<CourseDetails?> GetCourseDetailsAsync(int CourseDetailsId)
        {
            var courseDetails = await _context.CourseDetails.FirstOrDefaultAsync(ce => ce.Id == CourseDetailsId);

            return courseDetails;
        }

        public async Task<CourseDetails?> UpdateCourseDetailsAsync(CourseDetails courseDetails)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return courseDetails;
        }
    }
}