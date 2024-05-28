using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<ICollection<Department>?> GetDepartmentsOfFacultyAsync(String FacultyName);
        Task<Department?> GetDepartmentAsync(String DepartmantName);
        Task<Department?> CreateDepartmentAsync(Department department);
        Task<Department?> UpdateDepartmentAsync(Department department);
        Task<Department?> DeleteDepartmentAsync(String DepartmantName);
    }
}