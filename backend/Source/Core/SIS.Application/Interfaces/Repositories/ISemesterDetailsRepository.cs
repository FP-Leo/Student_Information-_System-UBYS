using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface ISemesterDetailsRepository
    {
        Task<SemesterDetail?> GetSemesterDetailsAsync(string DeparmentName, int Semester);
        Task<SemesterDetail?> AddSemesterDetailsAsync(SemesterDetail semesterDetail);
        Task<SemesterDetail?> UpdateSemesterDetailsAsync(SemesterDetail semesterDetail);
        Task<SemesterDetail?> DeleteSemesterDetailsAsync(string DeparmentName, int Semester);
        Task<int> GetNumOfCoursesInAcademicYear(int AcademicYear);
    }
}