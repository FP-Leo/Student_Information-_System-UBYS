using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StudentDepDetailsRepository : IStudentDepDetailsRepository
    {
        private readonly ApplicationDBContext _context;

        public StudentDepDetailsRepository(ApplicationDBContext context){
            _context = context;
        }

        public async Task<StudentDepDetail?> CreateStudentDepDetailAsync(StudentDepDetail studentDepDetail)
        {
            await _context.AddAsync(studentDepDetail);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return studentDepDetail;
        }

        public async Task<StudentDepDetail?> DeleteStudentDepDetailAsync(String TC, String depName)
        {
            var studentDepDetail = await GetStudentDepDetailAsync(TC, depName);

            if (studentDepDetail == null){
                return null;
            }

            _context.Remove(studentDepDetail);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return studentDepDetail;
        }

        public async Task<StudentDepDetail?> GetStudentDepDetailAsync(String TC, String depName)
        {
            var studentDepDetail = await _context.StudentDepDetails.FirstOrDefaultAsync(dd=> dd.TC == TC && dd.DepartmentName == depName);

            return studentDepDetail;
        }

        public async Task<ICollection<StudentDepDetail>> GetStudentDepDetailsByTCAsync(string TC)
        {
            var studentDepDetail = await _context.StudentDepDetails.Where(dd=> dd.TC == TC).ToListAsync();

            return studentDepDetail;
        }

        public async Task<StudentDepDetail?> UpdateStudentDepDetailAsync(StudentDepDetail studentDepDetail)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return studentDepDetail;
        }
    }
}