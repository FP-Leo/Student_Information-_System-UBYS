using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IClassDateRepository
    {
        Task<ClassDate?> GetClassDateByIdAsync(int Id);
        Task<ClassDate?> CreateClassDateAsync(ClassDate classdate);
        Task<ClassDate?> UpdateClassDateAsync(ClassDate classdate);
        Task<ClassDate?> DeleteClassDateByIdAsync(int id);
    }
}