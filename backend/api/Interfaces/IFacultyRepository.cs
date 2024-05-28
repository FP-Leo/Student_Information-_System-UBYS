using api.Models;

namespace api.Interfaces
{
    public interface IFacultyRepository
    {
        Task<ICollection<Faculty>?> GetUniFacultiesAsync(String UniName);
        Task<Faculty?> GetUniFacultyAsync(String UniName, String FacultyName);
        Task<Faculty?> CreateFacultyAsync(Faculty faculty);
        Task<Faculty?> UpdateFacultyAsync(Faculty faculty);
        Task<Faculty?> DeleteUniFacultyAsync(String UniName, String FacultyName);
    }
}