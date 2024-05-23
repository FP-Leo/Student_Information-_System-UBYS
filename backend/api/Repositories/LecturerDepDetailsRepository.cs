using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class LecturerDepDetailsRepository : ILecturerDepDetailsRepository
    {
        private readonly ApplicationDBContext _context;

        public LecturerDepDetailsRepository(ApplicationDBContext context){
            _context = context;
        }

        public async Task<LecturerDepDetails?> AddLecturerToDepartment(LecturerDepDetails lecturerDepDetail)
        {
            await _context.AddAsync(lecturerDepDetail);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return lecturerDepDetail;
        }

        public async Task<ICollection<LecturerDepDetails>?> GetDepartmentsLecturersAsync(string DepName)
        {
            var lecturerDepDetail = await _context.LecturerDepDetails.Where(dd=> dd.DepartmentName == DepName).ToListAsync();

            return lecturerDepDetail;
        }

        public async Task<LecturerDepDetails?> GetLecturerDepDetailAsync(string DepName, string TC)
        {
            var lecturerDepDetail = await _context.LecturerDepDetails.FirstOrDefaultAsync(dd=> dd.TC == TC && dd.DepartmentName == DepName);

            return lecturerDepDetail;
        }

        public async Task<ICollection<LecturerDepDetails>?> GetLecturerDepsDetailsAsync(string TC)
        {
            var lecturerDepDetail = await _context.LecturerDepDetails.Where(dd=> dd.TC == TC).ToListAsync();

            return lecturerDepDetail;
        }

        public async Task<LecturerDepDetails?> DeleteLecturerDepDetail(string DepName, string TC)
        {
            var lecturerDepDetail = await GetLecturerDepDetailAsync(DepName, TC);

            if (lecturerDepDetail == null){
                return null;
            }

            _context.Remove(lecturerDepDetail);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return lecturerDepDetail;
        }

        public async Task<LecturerDepDetails?> UpdateLecturerDepDetail(LecturerDepDetails lecturerDepDetail)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return lecturerDepDetail;;
        }
    }
}