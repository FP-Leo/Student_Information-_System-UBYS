using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task<ICollection<Department>?> GetDepartmentsOfFacultyAsync(string FacultyName);
        Task<Department?> GetDepartmentAsync(string DepartmantName);
        Task<Department?> CreateDepartmentAsync(Department department);
        Task<Department?> UpdateDepartmentAsync(Department department);
        Task<Department?> DeleteDepartmentAsync(string DepartmantName);
    }
}