
using Microsoft.EntityFrameworkCore;
using SIS.Application.Interfaces.Repositories;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Contexts.Data;

namespace SIS.Persistence.Concretes.Repositories
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly ApplicationDBContext _context;
        public UniversityRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<University?> CreateUniversityAsync(University university)
        {
            await _context.AddAsync(university);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return university;
        }

        public async Task<University?> DeleteUniversityByIdAsync(int id)
        {
            var university = await GetUniversityByIdAsync(id);

            if (university == null)
            {
                return null;
            }

            _context.Remove(university);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return university;
        }

        public async Task<University?> GetUniversityByIdAsync(int id)
        {
            var university = await _context.Universities.FirstOrDefaultAsync(u => u.UniversityId == id);

            return university;
        }

        public async Task<University?> UpdateUniversityAsync(University university)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return university;
        }
    }
}