

using api.Models;

namespace api.Interfaces
{
    public interface ICourseClassRepository
    {
        Task<CourseClass?> GetCourseClassAsync(String DepartmentName, String CourseName, int SchoolYear);
        Task<ICollection<CourseClass>?> GetSpecificCourseClasses(string DepartmentName, int SchoolYear);
        Task<CourseClass?> AddCourseClassAsync(CourseClass courseClass);
        Task<CourseClass?> UpdateCourseClassAsync(CourseClass courseClass);
        Task<CourseClass?> DeleteCourseClassAsync(String DepartmentName, String CourseName, int SchoolYear);
    }
}