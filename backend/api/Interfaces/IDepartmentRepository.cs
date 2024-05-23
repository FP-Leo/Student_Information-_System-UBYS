using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task<Department?> GetDepartmentByNameAsync(String DepartmantName);
        Task<Department?> CreateDepartmentAsync(Department department);
        Task<Department?> UpdateDepartmentAsync(Department department);
        Task<Department?> DeleteDepartmentByIdAsync(int id);
        Task<Department?> DeleteDepartmentByNameAsync(String DepartmantName);
    }
}