using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<CourseClassDate?> DeleteCourseClassDateByIdAsync(int id)
        {
            var CourseClassDate = await GetCourseClassDateByIdAsync(id);

            if (CourseClassDate == null){
                return null;
            }

            _context.Remove(CourseClassDate);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return CourseClassDate;
        }

        public async Task<CourseClassDate?> GetCourseClassDateByIdAsync(int id)
        {
            var courseClassDate = await _context.CourseClassDates.FirstOrDefaultAsync(u => u.Id == id);

            return courseClassDate;
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