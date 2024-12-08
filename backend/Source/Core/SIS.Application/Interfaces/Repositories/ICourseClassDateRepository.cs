using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface ICourseClassDateRepository
    {
        Task<ICollection<CourseClassDate>?> GetCourseClassDatesAsync(string CourseCode);
        Task<CourseClassDate?> GetCourseClassDateAsync(string CourseCode, int ClassDateId);
        Task<CourseClassDate?> CreateCourseClassDateAsync(CourseClassDate courseClassDate);
        Task<CourseClassDate?> UpdateCourseClassDateAsync(CourseClassDate courseClassDate);
        Task<CourseClassDate?> DeleteCourseClassDateAsync(CourseClassDate courseClassDate);
    }
}