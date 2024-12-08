using Microsoft.EntityFrameworkCore;
using SIS.Application.Interfaces.Repositories;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Contexts.Data;

namespace SIS.Persistence.Concretes.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly ApplicationDBContext _context;
        public FacultyRepository(ApplicationDBContext context)
        {
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

        public async Task<Faculty?> DeleteUniFacultyAsync(string UniName, string FacultyName)
        {
            var faculty = await GetUniFacultyAsync(UniName, FacultyName);

            if (faculty == null)
            {
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
            var faculties = await _context.Faculties.Where(u => u.UniName == UniName).ToListAsync();

            return faculties;
        }

        public async Task<Faculty?> GetUniFacultyAsync(string UniName, string FacultyName)
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