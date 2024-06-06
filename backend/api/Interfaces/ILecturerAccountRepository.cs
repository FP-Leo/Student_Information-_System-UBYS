using api.Models;

namespace api.Interfaces
{
    public interface ILecturerAccountRepository
    {
        Task<LecturerAccount?> GetLecturerAccountByTCAsync(string TC);
        Task<ICollection<LecturerAccount>?> GetLecturerAccounts();
        Task<LecturerAccount?> CreateLecturerAccountAsync(LecturerAccount LecturerAccount);
        Task<LecturerAccount?> UpdateLecturerAccountAsync(LecturerAccount LecturerAccount);
        Task<LecturerAccount?> DeleteLecturerAccountAsync(LecturerAccount LecturerAccount);
    }
}