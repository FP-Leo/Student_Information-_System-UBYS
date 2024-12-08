using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface ICourseClassRepository
    {
        Task<CourseClass?> GetCourseClassAsync(string CourseCode, int SchoolYear);
        Task<CourseClass?> AddCourseClassAsync(CourseClass courseClass);
        Task<CourseClass?> UpdateCourseClassAsync(CourseClass courseClass);
        Task<CourseClass?> DeleteCourseClassAsync(string CourseCode, int SchoolYear);
        Task<ICollection<CourseClass>?> GetLecturersClasses(string TC, int SchoolYear);
        Task<ICollection<CourseClass>?> GetLecturersDepClasses(string DepartmentName, string TC, int SchoolYear);
    }
}