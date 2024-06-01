using api.Models;

namespace api.Interfaces
{
    public interface IClassDateRepository
    {
        Task<ClassDate?> GetClassDateIdAsync(String day, TimeOnly time, int NumberOfClasses);
        Task<ClassDate?> GetClassDateByIdAsync(int Id);
        Task<ClassDate?> CreateClassDateAsync(ClassDate classdate);
        Task<ClassDate?> UpdateClassDateAsync(ClassDate classdate);
        Task<ClassDate?> DeleteClassDateByIdAsync(int id);
    }
}