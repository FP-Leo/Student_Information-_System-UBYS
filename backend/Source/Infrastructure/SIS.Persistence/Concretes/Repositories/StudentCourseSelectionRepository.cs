using Microsoft.EntityFrameworkCore;
using SIS.Application.Interfaces.Repositories;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Contexts.Data;

namespace SIS.Persistence.Concretes.Repositories
{
    public class StudentCourseSelectionRepository : IStudentCourseSelectionRepository
    {
        private readonly ApplicationDBContext _context;
        public StudentCourseSelectionRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<StudentCourseSelection?> AddCourseSelectionDetailsAsync(StudentCourseSelection courseSelectionDetails)
        {
            await _context.AddAsync(courseSelectionDetails);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return courseSelectionDetails;
        }
        public async Task<StudentCourseSelection?> DeleteCourseSelectionDetailsAsync(StudentCourseSelection courseSelectionDetails)
        {
            _context.Remove(courseSelectionDetails);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return courseSelectionDetails;
        }
        public async Task<StudentCourseSelection?> GetCourseSelectionDetailsAsync(string DepartmentName, string TC)
        {
            var courseSelection = await _context.StudentCourseSelections.FirstOrDefaultAsync(scs => scs.DepartmentName == DepartmentName && scs.TC == TC);

            return courseSelection;
        }

        public async Task<StudentCourseSelection?> UpdateCourseSelectionDetailsAsync(StudentCourseSelection courseSelectionDetails)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return courseSelectionDetails;
        }
    }
}