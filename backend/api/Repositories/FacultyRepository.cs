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

        public async Task<Faculty?> DeleteUniFacultyAsync(String UniName, String FacultyName)
        {
            var faculty = await GetUniFacultyAsync(UniName, FacultyName);

            if (faculty == null){
                return null;
            }

            _context.Remove(faculty);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return faculty;
        }

        public async Task<ICollection<Faculty>?> GetUniFacultiesAsync(string UniName)
        {
            var faculties= await _context.Faculties.Where(u => u.UniName == UniName).ToListAsync();

            return faculties;
        }

        public async Task<Faculty?> GetUniFacultyAsync(String UniName, String FacultyName)
        {
            var faculty = await _context.Faculties.FirstOrDefaultAsync(u => u.FacultyName == FacultyName && u.UniName == UniName);

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