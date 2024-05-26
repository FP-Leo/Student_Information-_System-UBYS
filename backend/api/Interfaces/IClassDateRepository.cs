using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public class IClassDateRepository
    {
        Task<ClassDate?> GetClassDateByIdAsync(int id);
        Task<ClassDate?> CreateClassDatesityAsync(ClassDate classdate);
        Task<ClassDate?> UpdateClassDateAsync(ClassDate classdate);
        Task<ClassDate?> DeleteClassDateByIdAsync(int id);
    }
}