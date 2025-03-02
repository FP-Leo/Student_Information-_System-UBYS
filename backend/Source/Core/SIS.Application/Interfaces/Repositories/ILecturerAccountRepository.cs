using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface ILecturerAccountRepository
    {
        Task<LecturerAccount?> GetLecturerAccountByTCAsync(string TC);
        Task<LecturerAccount?> GetLecturerAccountByIDAsync(int ID);
        Task<ICollection<LecturerAccount>?> GetLecturerAccounts();
        Task<LecturerAccount?> CreateLecturerAccountAsync(LecturerAccount LecturerAccount);
        Task<LecturerAccount?> UpdateLecturerAccountAsync(LecturerAccount LecturerAccount);
        Task<LecturerAccount?> DeleteLecturerAccountAsync(LecturerAccount LecturerAccount);
    }
}