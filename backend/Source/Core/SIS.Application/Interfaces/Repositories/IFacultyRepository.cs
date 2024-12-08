using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface IFacultyRepository
    {
        Task<ICollection<Faculty>?> GetUniFacultiesAsync(string UniName);
        Task<Faculty?> GetUniFacultyAsync(string UniName, string FacultyName);
        Task<Faculty?> CreateFacultyAsync(Faculty faculty);
        Task<Faculty?> UpdateFacultyAsync(Faculty faculty);
        Task<Faculty?> DeleteUniFacultyAsync(string UniName, string FacultyName);
    }
}