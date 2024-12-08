using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface IStudentCourseSelectRepository
    {
        Task<ICollection<StudentCourseSelect>?> GetSelectedCoursesAsync(string DepartmentName, string TC);
        Task<ICollection<StudentCourseSelect>?> AddSelectedCoursesAsync(ICollection<StudentCourseSelect> selectedCourses);
        Task<ICollection<StudentCourseSelect>?> DeleteSelectedCoursesRangeAsync(ICollection<StudentCourseSelect> selectedCourses);
        Task<ICollection<StudentCourseSelect>?> UpdateSelectedCoursesAsync(ICollection<StudentCourseSelect> selectedCourses);
        Task<StudentCourseSelect?> GetSelectedCourseAsync(string TC, string CourseCode);
        Task<StudentCourseSelect?> AddSelectedCourseAsync(StudentCourseSelect selectedCourse);
        Task<StudentCourseSelect?> DeleteSelectedCourseAsync(StudentCourseSelect selectedCourse);
        Task<StudentCourseSelect?> UpdateSelectedCourseAsync(StudentCourseSelect selectedCourse);
    }
}