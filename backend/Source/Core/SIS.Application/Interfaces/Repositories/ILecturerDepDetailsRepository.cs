using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface ILecturerDepDetailsRepository
    {
        Task<ICollection<LecturerDepDetails>?> GetLecturerDepsDetailsAsync(string TC);
        Task<ICollection<LecturerDepDetails>?> GetLecturerDepsDetailsAsync(int ID);
        Task<ICollection<LecturerDepDetails>?> GetDepartmentsLecturersAsync(string DepName);
        Task<LecturerDepDetails?> GetLecturerDepDetailAsync(string DepName, string TC);
        Task<LecturerDepDetails?> GetLecturerDepDetailAsync(string DepName, int ID);
        Task<LecturerDepDetails?> AddLecturerToDepartment(LecturerDepDetails lecturerDepDetail);
        Task<LecturerDepDetails?> UpdateLecturerDepDetail(LecturerDepDetails lecturerDepDetail);
        Task<LecturerDepDetails?> DeleteLecturerDepDetail(string DepName, string TC);
    }
}