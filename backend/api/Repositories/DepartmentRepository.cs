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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDBContext _context;
        public DepartmentRepository(ApplicationDBContext context){
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
        public async Task<Department?> DeleteDepartmentAsync(String DepartmantName)
        {
            var department = await GetDepartmentAsync(DepartmantName);

            if (department == null){
                return null;
            }

            _context.Remove(department);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return department;
        }
        public async Task<Department?> GetDepartmentAsync(String DepartmantName)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentName == DepartmantName);

            return department;
        }
        public async Task<ICollection<Department>?> GetDepartmentsOfFacultyAsync(String FacultyName)
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