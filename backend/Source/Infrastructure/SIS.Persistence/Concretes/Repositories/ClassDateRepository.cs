using Microsoft.EntityFrameworkCore;
using SIS.Application.Interfaces.Repositories;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Contexts.Data;

namespace SIS.Persistence.Concretes.Repositories
{
    public class ClassDateRepository : IClassDateRepository
    {
        private readonly ApplicationDBContext _context;
        public ClassDateRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ClassDate?> CreateClassDateAsync(ClassDate classDate)
        {
            await _context.AddAsync(classDate);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return classDate;
        }

        public async Task<ClassDate?> DeleteClassDateByIdAsync(int id)
        {
            var ClassDate = await GetClassDateByIdAsync(id);

            if (ClassDate == null)
            {
                return null;
            }

            _context.Remove(ClassDate);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return ClassDate;
        }

        public async Task<ClassDate?> GetClassDateByIdAsync(int id)
        {
            var classDate = await _context.ClassDates.FirstOrDefaultAsync(u => u.Id == id);

            return classDate;
        }

        public async Task<ClassDate?> GetClassDateIdAsync(string day, TimeOnly time, int NumberOfClasses)
        {
            var classDate = await _context.ClassDates.FirstOrDefaultAsync(u => u.Day == day && u.Time == time && u.NumberOfClasses == NumberOfClasses);

            return classDate;
        }

        public async Task<ClassDate?> UpdateClassDateAsync(ClassDate classDate)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return classDate;
        }
    }
}