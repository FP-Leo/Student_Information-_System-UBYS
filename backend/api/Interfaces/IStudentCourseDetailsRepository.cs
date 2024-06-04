using api.Models;

namespace api.Interfaces
{
    public interface IStudentCourseDetailsRepostiory
    {
        Task<StudentCourseDetails?> GetStudentCourseDetails(String CourseCode, String TC, int SchoolYear);
        Task<ICollection<StudentCourseDetails>?> GetStudentCourseDetails(String CourseCode, String TC);
        Task<ICollection<StudentCourseDetails>?> GetAllStudentsCourseDetails(String CourseCode, int SchoolYear);
        Task<int> GetStudentCountInCourse(String CourseCode, int SchoolYear);
        Task<ICollection<StudentCourseDetails>?> GetStudentsAllCourseDetails(String Department, String TC);
        Task<StudentCourseDetails?> CreateStudentCourseDetails(StudentCourseDetails studentCourseDetails);
        Task<StudentCourseDetails?> UpdateStudentCourseDetailsAsync(StudentCourseDetails studentCourseDetails);
        Task<StudentCourseDetails?> DeleteStudentCourseDetailsAsync(String CourseCode, String TC, int SchoolYear);
        Task<ICollection<StudentCourseDetails>?> GetActiveCoursesAsync(String DepName, String TC);
        Task<ICollection<StudentCourseDetails>?> GetFailedCoursesAsync(String DepName, String TC, int semType);
        Task<ICollection<StudentCourseDetails>?> GetPassedCoursesAsync(String DepName, String TC, int semType);
        Task<ICollection<StudentCourseDetails>?> GetPartiallyPassedCoursesAsync(String DepName, String TC, int semType);
        Task<ICollection<StudentCourseDetails>?> GetSemesterFailedCoursesAsync(String DepName, String TC, int sem);
        Task<ICollection<StudentCourseDetails>?> GetSemesterPassedCoursesAsync(String DepName, String TC, int sem);
        Task<ICollection<StudentCourseDetails>?> GetSemesterPartiallyPassedCoursesAsync(String DepName, String TC, int sem);
    }
}