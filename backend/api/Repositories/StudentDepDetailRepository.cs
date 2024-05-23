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

        public async Task<StudentDepDetail?> DeleteStudentDepDetailAsync(String TC, int id)
        {
            var studentDepDetail = await GetStudentDepDetailByTcAndDepIdAsync(TC, id);

            if (studentDepDetail == null){
                return null;
            }

            _context.Remove(studentDepDetail);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return studentDepDetail;
        }

        public async Task<StudentDepDetail?> GetStudentDepDetailByTcAndDepIdAsync(string TC, int depId)
        {
            var studentDepDetail = await _context.StudentDepDetails.FirstOrDefaultAsync(dd=> dd.TC == TC && dd.DepartmentId == depId);

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