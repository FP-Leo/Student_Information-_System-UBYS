using api.Models;

namespace api.Interfaces
{
    public interface IStudentCourseSelectionRepository
    {
        Task<StudentCourseSelection?> GetCourseSelectionDetailsAsync(String DepartmentName, String TC);
        Task<StudentCourseSelection?> AddCourseSelectionDetailsAsync(StudentCourseSelection courseSelectionDetails);
        Task<StudentCourseSelection?> DeleteCourseSelectionDetailsAsync(StudentCourseSelection courseSelectionDetails);
        Task<StudentCourseSelection?> UpdateCourseSelectionDetailsAsync(StudentCourseSelection courseSelectionDetails);
    }
}