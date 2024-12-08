using Microsoft.EntityFrameworkCore;
using SIS.Application.Interfaces.Repositories;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Contexts.Data;

namespace SIS.Persistence.Concretes.Repositories
{
    public class StudentDepDetailsRepository : IStudentDepDetailsRepository
    {
        private readonly ApplicationDBContext _context;

        public StudentDepDetailsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<StudentDepDetails?> CreateStudentDepDetailAsync(StudentDepDetails studentDepDetail)
        {
            await _context.AddAsync(studentDepDetail);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return studentDepDetail;
        }

        public async Task<StudentDepDetails?> DeleteStudentDepDetailAsync(string TC, string depName)
        {
            var studentDepDetail = await GetStudentDepDetailAsync(TC, depName);

            if (studentDepDetail == null)
            {
                return null;
            }

            _context.Remove(studentDepDetail);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return studentDepDetail;
        }

        public async Task<StudentDepDetails?> GetStudentDepDetailAsync(string TC, string depName)
        {
            var studentDepDetail = await _context.StudentsDepDetails.FirstOrDefaultAsync(dd => dd.TC == TC && dd.DepartmentName == depName);

            return studentDepDetail;
        }

        public async Task<ICollection<StudentDepDetails>> GetStudentDepDetailsByTCAsync(string TC)
        {
            var studentDepDetail = await _context.StudentsDepDetails.Where(dd => dd.TC == TC).ToListAsync();

            return studentDepDetail;
        }

        public async Task<ICollection<StudentDepDetails>?> GetDepartmentsStudentsAsync(string DepName)
        {
            var studentsDepDetail = await _context.StudentsDepDetails.Where(dd => dd.DepartmentName == DepName).ToListAsync();

            return studentsDepDetail;
        }

        public async Task<StudentDepDetails?> UpdateStudentDepDetailAsync(StudentDepDetails studentDepDetail)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return studentDepDetail;
        }
    }
}