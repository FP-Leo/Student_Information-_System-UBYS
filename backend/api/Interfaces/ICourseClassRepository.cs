

using api.Models;

namespace api.Interfaces
{
    public interface ICourseClassRepository
    {
        Task<CourseClass?> GetCourseClassAsync(String CourseCode, int SchoolYear);
        Task<CourseClass?> AddCourseClassAsync(CourseClass courseClass);
        Task<CourseClass?> UpdateCourseClassAsync(CourseClass courseClass);
        Task<CourseClass?> DeleteCourseClassAsync(String CourseCode, int SchoolYear);
    }
}