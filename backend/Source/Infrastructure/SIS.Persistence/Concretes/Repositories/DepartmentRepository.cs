using Microsoft.EntityFrameworkCore;
using SIS.Application.Interfaces.Repositories;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Contexts.Data;

namespace SIS.Persistence.Concretes.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDBContext _context;
        public DepartmentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Department?> CreateDepartmentAsync(Department department)
        {
            await _context.AddAsync(department);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return department;
        }
        public async Task<Department?> DeleteDepartmentAsync(string DepartmantName)
        {
            var department = await GetDepartmentAsync(DepartmantName);

            if (department == null)
            {
                return null;
            }

            _context.Remove(department);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return department;
        }
        public async Task<Department?> GetDepartmentAsync(string DepartmantName)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentName == DepartmantName);

            return department;
        }
        public async Task<ICollection<Department>?> GetDepartmentsOfFacultyAsync(string FacultyName)
        {
            var departments = await _context.Departments.Where(d => d.FacultyName == FacultyName).ToListAsync();

            return departments;
        }
        public async Task<Department?> UpdateDepartmentAsync(Department department)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return department;
        }
    }
}