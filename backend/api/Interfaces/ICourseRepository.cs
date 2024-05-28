using api.Models;

namespace api.Interfaces
{
    public interface ICourseRepository
    {
        Task<ICollection<Course>> GetCoursesAsync();
        Task<Course?> GetCourseAsync(String CourseName);
        Task<Course?> GetCourseAsync(int CourseId);
        Task<Course?> AddCourseAsync(Course course);
        Task<Course?> UpdateCourseAsync(Course course);
        Task<Course?> DeleteCourseAsync(String CourseName);
    }
}