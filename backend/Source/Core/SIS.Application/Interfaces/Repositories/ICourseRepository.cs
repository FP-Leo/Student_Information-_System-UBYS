using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Task<ICollection<Course>> GetCoursesAsync();
        Task<Course?> GetCourseAsync(string CourseName);
        Task<Course?> GetCourseAsync(int CourseId);
        Task<Course?> AddCourseAsync(Course course);
        Task<Course?> UpdateCourseAsync(Course course);
        Task<Course?> DeleteCourseAsync(string CourseName);
    }
}