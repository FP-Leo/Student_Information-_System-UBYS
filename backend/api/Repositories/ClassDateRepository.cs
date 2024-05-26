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
    public class ClassDateRepository : IClassDateRepository
    {
         private readonly ApplicationDBContext _context;
        public ClassDateRepository(ApplicationDBContext context){
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

            if (ClassDate == null){
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

        public async Task<ClassDate?> UpdateClassDateAsync(ClassDate classDate)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return classDate;
        }
    }
}