using api.Models;

namespace api.Interfaces
{
    public interface IDepartmentCourseRepository
    {
        Task<ICollection<DepartmentCourse>> GetDepartmentsOfCourseByCourseNameAsync(String CourseName);
        Task<ICollection<DepartmentCourse>> GetDepartmentCoursesAsync(String DepartmantName);
        Task<DepartmentCourse?> GetDeparmentCourseAsync(String CourseName, String DepartmantName);
        Task<DepartmentCourse?> AddCourseToDepAsync(DepartmentCourse course);
        Task<DepartmentCourse?> UpdateDepsCourseAsync(DepartmentCourse course);
        Task<DepartmentCourse?> DeleteCourseFromDepAsync(String CourseName, String DepartmantName);
    }
}