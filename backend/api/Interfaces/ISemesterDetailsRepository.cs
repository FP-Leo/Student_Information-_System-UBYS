using api.Models;

namespace api.Interfaces
{
    public interface ISemesterDetailsRepository
    {
        Task<SemesterDetail?> GetSemesterDetailsAsync(String DeparmentName, int Semester);
        Task<SemesterDetail?> AddSemesterDetailsAsync(SemesterDetail semesterDetail);
        Task<SemesterDetail?> UpdateSemesterDetailsAsync(SemesterDetail semesterDetail);
        Task<SemesterDetail?> DeleteSemesterDetailsAsync(String DeparmentName, int Semester);
        Task<int> GetNumOfCoursesInAcademicYear(int AcademicYear);
    }
}