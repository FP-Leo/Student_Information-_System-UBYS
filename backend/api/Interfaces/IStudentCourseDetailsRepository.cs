using api.Models;

namespace api.Interfaces
{
    public interface IStudentCourseDetailsRepostiory
    {
        Task<StudentCourseDetails?> GetStudentCourseDetails(String? Department, String? Course, String? TC);
        Task<ICollection<StudentCourseDetails>?> GetAllStudentsCourseDetails(String? Department, String? Course);
        Task<ICollection<StudentCourseDetails>?> GetStudentsAllCourseDetails(String? Department, String? TC);
        Task<StudentCourseDetails?> CreateStudentCourseDetails(StudentCourseDetails studentCourseDetails);
        Task<StudentCourseDetails?> UpdateStudentCourseDetails(StudentCourseDetails studentCourseDetails);
        Task<StudentCourseDetails?> DeleteStudentCourseDetails(String? Department, String? Course, String? TC);
    }
}