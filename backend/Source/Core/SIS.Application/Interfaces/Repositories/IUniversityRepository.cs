using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface IUniversityRepository
    {
        Task<University?> GetUniversityByIdAsync(int id);
        Task<University?> CreateUniversityAsync(University university);
        Task<University?> UpdateUniversityAsync(University university);
        Task<University?> DeleteUniversityByIdAsync(int id);
    }
}