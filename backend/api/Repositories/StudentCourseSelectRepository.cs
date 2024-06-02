using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StudentCourseSelectRepository : IStudentCourseSelectRepository
    {
        private readonly ApplicationDBContext _context;
        public StudentCourseSelectRepository(ApplicationDBContext context){
            _context = context;
        }
        public async Task<StudentCourseSelect?> AddSelectedCourseAsync(StudentCourseSelect selectedCourse)
        {
            await _context.AddAsync(selectedCourse);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return selectedCourse;
        }

        public async Task<ICollection<StudentCourseSelect>?> AddSelectedCoursesAsync(ICollection<StudentCourseSelect> selectedCourses)
        {
            await _context.AddRangeAsync(selectedCourses);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return selectedCourses;
        }
        public async Task<ICollection<StudentCourseSelect>?> DeleteSelectedCoursesAsync(ICollection<StudentCourseSelect> selectedCourses)
        {
            _context.RemoveRange(selectedCourses);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return selectedCourses;
        }

        public async Task<StudentCourseSelect?> DeleteSelectedCoursesAsync(StudentCourseSelect selectedCourse)
        {
            _context.Remove(selectedCourse);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return selectedCourse;
        }

        public async Task<StudentCourseSelect?> GetSelectedCourseAsync(string TC, string CourseCode)
        {
            var selectedCourse = await _context.StudentSelectedCourses.FirstOrDefaultAsync(sc => sc.TC == TC && sc.CourseCode == CourseCode);

            return selectedCourse;
        }

        public async Task<ICollection<StudentCourseSelect>?> GetSelectedCoursesAsync(string DepartmentName, string TC)
        {
            var selectedCourses = await _context.StudentSelectedCourses.Where(sc => sc.TC == TC && sc.DepartmentName == DepartmentName).ToListAsync();

            return selectedCourses;
        }

        public async Task<StudentCourseSelect?> UpdateSelectedCourseAsync(StudentCourseSelect selectedCourse)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return selectedCourse;
        }

        public async Task<ICollection<StudentCourseSelect>?> UpdateSelectedCoursesAsync(ICollection<StudentCourseSelect> selectedCourses)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return selectedCourses;
        }
    }
}