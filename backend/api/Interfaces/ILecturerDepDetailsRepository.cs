using api.Models;

namespace api.Interfaces
{
    public interface ILecturerDepDetailsRepository
    {
        Task<ICollection<LecturerDepDetails>?> GetLecturerDepsDetailsAsync(String TC);
        Task<ICollection<LecturerDepDetails>?> GetLecturerDepsDetailsAsync(int LecturerId);
        Task<ICollection<LecturerDepDetails>?> GetDepartmentsLecturersAsync(String DepName);
        Task<LecturerDepDetails?> GetLecturerDepDetailAsync(String DepName, String TC);
        Task<LecturerDepDetails?> GetLecturerDepDetailAsync(String DepName, int LecturerId);
        Task<LecturerDepDetails?> AddLecturerToDepartment(LecturerDepDetails lecturerDepDetail);
        Task<LecturerDepDetails?> UpdateLecturerDepDetail(LecturerDepDetails lecturerDepDetail);
        Task<LecturerDepDetails?> DeleteLecturerDepDetail(String DepName, String TC);
    }
}