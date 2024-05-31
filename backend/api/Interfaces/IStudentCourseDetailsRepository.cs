using api.Models;

namespace api.Interfaces
{
    public interface IStudentCourseDetailsRepostiory
    {
        Task<StudentCourseDetails?> GetStudentCourseDetails(String CourseCode, String TC);
        Task<ICollection<StudentCourseDetails>?> GetAllStudentsCourseDetails(String CourseCode);
        Task<ICollection<StudentCourseDetails>?> GetStudentsAllCourseDetails(String Department, String TC);
        Task<StudentCourseDetails?> CreateStudentCourseDetails(StudentCourseDetails studentCourseDetails);
        Task<StudentCourseDetails?> UpdateStudentCourseDetailsAsync(StudentCourseDetails studentCourseDetails);
        Task<StudentCourseDetails?> DeleteStudentCourseDetailsAsync(String CourseCode, String TC);
        Task<ICollection<StudentCourseDetails>?> GetActiveCoursesAsync(String DepName, String TC);
        Task<ICollection<StudentCourseDetails>?> GetFailedCoursesAsync(String DepName, String TC, int semType);
        Task<ICollection<StudentCourseDetails>?> GetPassedCoursesAsync(String DepName, String TC, int semType);
        Task<ICollection<StudentCourseDetails>?> GetPartiallyPassedCoursesAsync(String DepName, String TC, int semType);
    }
}