using api.Models;

namespace api.Interfaces
{
    public interface ICourseClassDateRepository
    {
        Task<ICollection<CourseClassDate>?> GetCourseClassDatesAsync(String CourseCode);
        Task<CourseClassDate?> GetCourseClassDateAsync(String CourseCode, int ClassDateId);
        Task<CourseClassDate?> CreateCourseClassDateAsync(CourseClassDate courseClassDate);
        Task<CourseClassDate?> UpdateCourseClassDateAsync(CourseClassDate courseClassDate);
        Task<CourseClassDate?> DeleteCourseClassDateAsync(CourseClassDate courseClassDate);
    }
}