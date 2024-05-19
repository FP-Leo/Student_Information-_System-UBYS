using api.Models;

namespace api.Interfaces
{
    public interface IFacultyRepository
    {
        Task<Faculty?> GetFacultyByIdAsync(int id);
        Task<Faculty?> CreateFacultyAsync(Faculty faculty);
        Task<Faculty?> UpdateFacultyAsync(Faculty faculty);
        Task<Faculty?> DeleteFacultyByIdAsync(int id);
    }
}