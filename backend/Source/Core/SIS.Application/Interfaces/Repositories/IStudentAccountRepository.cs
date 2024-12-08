using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface IStudentAccountRepository
    {
        Task<ICollection<StudentAccount>?> GetAllActiveStudents();
        Task<StudentAccount?> GetStudentAccountByTCAsync(string TC);
        Task<StudentAccount?> GetStudentAccountByIDAsync(int ID);
        Task<StudentAccount?> CreateStudentAccountAsync(StudentAccount studentAccount);
        Task<StudentAccount?> UpdateStudentAccountAsync(StudentAccount studentAccount);
        Task<StudentAccount?> DeleteStudentAccountAsync(StudentAccount studentAccount);
    }
}