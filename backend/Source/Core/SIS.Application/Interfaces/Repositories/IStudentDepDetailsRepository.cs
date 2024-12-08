using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface IStudentDepDetailsRepository
    {
        Task<ICollection<StudentDepDetails>> GetStudentDepDetailsByTCAsync(string TC);
        Task<StudentDepDetails?> GetStudentDepDetailAsync(string TC, string depName);
        Task<ICollection<StudentDepDetails>?> GetDepartmentsStudentsAsync(string DepName);
        Task<StudentDepDetails?> CreateStudentDepDetailAsync(StudentDepDetails studentDepDetail);
        Task<StudentDepDetails?> UpdateStudentDepDetailAsync(StudentDepDetails studentDepDetail);
        Task<StudentDepDetails?> DeleteStudentDepDetailAsync(string TC, string depName);
    }
}