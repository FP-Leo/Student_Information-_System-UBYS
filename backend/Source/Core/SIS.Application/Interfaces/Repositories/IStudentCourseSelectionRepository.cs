using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface IStudentCourseSelectionRepository
    {
        Task<StudentCourseSelection?> GetCourseSelectionDetailsAsync(string DepartmentName, string TC);
        Task<StudentCourseSelection?> AddCourseSelectionDetailsAsync(StudentCourseSelection courseSelectionDetails);
        Task<StudentCourseSelection?> DeleteCourseSelectionDetailsAsync(StudentCourseSelection courseSelectionDetails);
        Task<StudentCourseSelection?> UpdateCourseSelectionDetailsAsync(StudentCourseSelection courseSelectionDetails);
    }
}