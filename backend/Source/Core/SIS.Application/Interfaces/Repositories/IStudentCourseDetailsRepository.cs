using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface IStudentCourseDetailsRepostiory
    {
        Task<StudentCourseDetails?> GetStudentCourseDetails(string CourseCode, string TC, int SchoolYear);
        Task<ICollection<StudentCourseDetails>?> GetStudentCourseDetails(string CourseCode, string TC);
        Task<ICollection<StudentCourseDetails>?> GetAllStudentsCourseDetails(string CourseCode, int SchoolYear);
        Task<int> GetStudentCountInCourse(string CourseCode, int SchoolYear);
        Task<ICollection<StudentCourseDetails>?> GetStudentsAllCourseDetails(string Department, string TC);
        Task<StudentCourseDetails?> CreateStudentCourseDetails(StudentCourseDetails studentCourseDetails);
        Task<StudentCourseDetails?> UpdateStudentCourseDetailsAsync(StudentCourseDetails studentCourseDetails);
        Task<StudentCourseDetails?> DeleteStudentCourseDetailsAsync(string CourseCode, string TC, int SchoolYear);
        Task<ICollection<StudentCourseDetails>?> GetActiveCoursesAsync(string DepName, string TC);
        Task<ICollection<StudentCourseDetails>?> GetFailedCoursesAsync(string DepName, string TC, int semType);
        Task<ICollection<StudentCourseDetails>?> GetPassedCoursesAsync(string DepName, string TC, int semType);
        Task<ICollection<StudentCourseDetails>?> GetPartiallyPassedCoursesAsync(string DepName, string TC, int semType);
        Task<ICollection<StudentCourseDetails>?> GetSemesterFailedCoursesAsync(string DepName, string TC, int sem);
        Task<ICollection<StudentCourseDetails>?> GetSemesterPassedCoursesAsync(string DepName, string TC, int sem);
        Task<ICollection<StudentCourseDetails>?> GetSemesterPartiallyPassedCoursesAsync(string DepName, string TC, int sem);
    }
}