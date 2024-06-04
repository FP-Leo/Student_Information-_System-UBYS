using api.Models;

namespace api.Interfaces
{
    public interface IStudentCourseSelectRepository
    {
        Task<ICollection<StudentCourseSelect>?> GetSelectedCoursesAsync(String DepartmentName, String TC);
        Task<ICollection<StudentCourseSelect>?> AddSelectedCoursesAsync(ICollection<StudentCourseSelect> selectedCourses);
        Task<ICollection<StudentCourseSelect>?> DeleteSelectedCoursesRangeAsync(ICollection<StudentCourseSelect> selectedCourses);
        Task<ICollection<StudentCourseSelect>?> UpdateSelectedCoursesAsync(ICollection<StudentCourseSelect> selectedCourses);
        Task<StudentCourseSelect?> GetSelectedCourseAsync(String TC, String CourseCode);
        Task<StudentCourseSelect?> AddSelectedCourseAsync(StudentCourseSelect selectedCourse);
        Task<StudentCourseSelect?> DeleteSelectedCourseAsync(StudentCourseSelect selectedCourse);
        Task<StudentCourseSelect?> UpdateSelectedCourseAsync(StudentCourseSelect selectedCourse);
    }
}