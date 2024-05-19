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
    public class FacultyRepository : IFacultyRepository
    {
        private readonly ApplicationDBContext _context;
        public FacultyRepository(ApplicationDBContext context){
            _context = context;
        }
        public async Task<Faculty?> CreateFacultyAsync(Faculty faculty)
        {
            await _context.AddAsync(faculty);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return faculty;
        }

        public async Task<Faculty?> DeleteFacultyByIdAsync(int id)
        {
            var faculty = await GetFacultyByIdAsync(id);

            if (faculty == null){
                return null;
            }

            _context.Remove(faculty);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return faculty;
        }

        public async Task<Faculty?> GetFacultyByIdAsync(int id)
        {
            var faculty = await _context.Faculties.FirstOrDefaultAsync(u => u.FacultyID == id);

            return faculty;
        }

        public async Task<Faculty?> UpdateFacultyAsync(Faculty faculty)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return faculty;
        }
    }
}