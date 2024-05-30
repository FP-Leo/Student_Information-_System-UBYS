using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;


namespace api.Repositories
{
    public class CourseClassDateRepository : ICourseClassDateRepository
    {
        private readonly ApplicationDBContext _context;
        public CourseClassDateRepository(ApplicationDBContext context){
            _context = context;
        }
        public async Task<CourseClassDate?> CreateCourseClassDateAsync(CourseClassDate courseClassDate)
        {
            await _context.AddAsync(courseClassDate);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return courseClassDate;
        }
        public async Task<CourseClassDate?> DeleteCourseClassDateAsync(CourseClassDate courseClassDate)
        {
            try{
                _context.Remove(courseClassDate);
                var result = await _context.SaveChangesAsync();
                if (result <= 0)
                    return null;
                return courseClassDate;
            }
            catch {
                return null;
            }
        }
        public async Task<CourseClassDate?> GetCourseClassDateAsync(string CourseCode, int ClassDateId)
        {
            var courseClassDate = await _context.CourseClassDates.FirstOrDefaultAsync(ccd => ccd.CourseCode == CourseCode && ccd.ClassDateId == ClassDateId);

            return courseClassDate;
        }
        public async Task<ICollection<CourseClassDate>?> GetCourseClassDatesAsync(String CourseCode)
        {
            var courseClassDates = await _context.CourseClassDates.Where(ccd => ccd.CourseCode == CourseCode).ToListAsync();

            return courseClassDates;
        }
        public async Task<CourseClassDate?> UpdateCourseClassDateAsync(CourseClassDate courseClassDate)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return courseClassDate;
        }
    }
}