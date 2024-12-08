using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface IClassDateRepository
    {
        Task<ClassDate?> GetClassDateIdAsync(string day, TimeOnly time, int NumberOfClasses);
        Task<ClassDate?> GetClassDateByIdAsync(int Id);
        Task<ClassDate?> CreateClassDateAsync(ClassDate classdate);
        Task<ClassDate?> UpdateClassDateAsync(ClassDate classdate);
        Task<ClassDate?> DeleteClassDateByIdAsync(int id);
    }
}