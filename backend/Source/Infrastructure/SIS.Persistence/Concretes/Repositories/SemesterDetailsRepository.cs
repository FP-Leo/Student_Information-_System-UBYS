using Microsoft.EntityFrameworkCore;
using SIS.Application.Interfaces.Repositories;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Contexts.Data;

namespace SIS.Persistence.Concretes.Repositories
{
    public class SemesterDetailsRepository : ISemesterDetailsRepository
    {
        private readonly ApplicationDBContext _context;
        public SemesterDetailsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<SemesterDetail?> AddSemesterDetailsAsync(SemesterDetail semesterDetail)
        {
            await _context.AddAsync(semesterDetail);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return semesterDetail;
        }

        public async Task<SemesterDetail?> DeleteSemesterDetailsAsync(string DeparmentName, int Semester)
        {
            var semesterDetail = await GetSemesterDetailsAsync(DeparmentName, Semester);

            if (semesterDetail == null)
            {
                return null;
            }

            _context.Remove(semesterDetail);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return semesterDetail;
        }

        public async Task<int> GetNumOfCoursesInAcademicYear(int AcademicYear)
        {
            var semesters = await _context.SemesterDetails.Where(sd => sd.AcademicYear == AcademicYear).ToListAsync();

            if (semesters == null)
            {
                return -1;
            }
            int TotalCourses = 0;
            foreach (var semester in semesters)
            {
                TotalCourses += semester.TotalCourses;
            }

            return TotalCourses;
        }

        public async Task<SemesterDetail?> GetSemesterDetailsAsync(string DeparmentName, int Semester)
        {
            var semesterDetail = await _context.SemesterDetails.FirstOrDefaultAsync(sd => sd.DepartmentName == DeparmentName && sd.Semester == Semester);

            return semesterDetail;
        }

        public async Task<SemesterDetail?> UpdateSemesterDetailsAsync(SemesterDetail semesterDetail)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return semesterDetail;
        }
    }
}