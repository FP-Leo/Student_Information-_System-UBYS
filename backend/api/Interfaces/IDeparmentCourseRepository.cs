using api.Models;

namespace api.Interfaces
{
    public interface IDepartmentCourseRepository
    {
        Task<ICollection<DepartmentCourse>> GetDepartmentsOfCourseByCourseNameAsync(String CourseName);
        Task<ICollection<DepartmentCourse>> GetDepartmentCoursesAsync(String DepartmentName);
        Task<ICollection<DepartmentCourse>> GetDepartmentSemesterCoursesAsync(String DepartmentName, int Semester);
        Task<DepartmentCourse?> GetDeparmentCourseAsync(String CourseName, String DepartmentName);
        Task<DepartmentCourse?> GetDeparmentCourseByCourseCodeAsync(String CourseCode);
        Task<DepartmentCourse?> AddCourseToDepAsync(DepartmentCourse course);
        Task<DepartmentCourse?> UpdateDepsCourseAsync(DepartmentCourse course);
        Task<DepartmentCourse?> DeleteCourseFromDepAsync(String CourseName, String DepartmentName);
    }
}