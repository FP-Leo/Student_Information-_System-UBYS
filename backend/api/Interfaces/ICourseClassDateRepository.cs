using api.Models;

namespace api.Interfaces
{
    public interface ICourseClassDateRepository
    {
        Task<ICollection<CourseClassDate>?> GetCourseClassDatesAsync(String DepartmentName, String CourseName);
        Task<CourseClassDate?> GetCourseClassDateAsync(String DepartmentName, String CourseName, int ClassDateId);
        Task<CourseClassDate?> CreateCourseClassDateAsync(CourseClassDate courseClassDate);
        Task<CourseClassDate?> UpdateCourseClassDateAsync(CourseClassDate courseClassDate);
        Task<CourseClassDate?> DeleteCourseClassDateAsync(CourseClassDate courseClassDate);
    }
}