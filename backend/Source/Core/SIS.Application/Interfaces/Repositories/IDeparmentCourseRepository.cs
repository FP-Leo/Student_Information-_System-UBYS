using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface IDepartmentCourseRepository
    {
        Task<ICollection<DepartmentCourse>?> GetActiveCourses();
        Task<ICollection<DepartmentCourse>?> GetDepartmentsOfCourseByCourseNameAsync(string CourseName);
        Task<ICollection<DepartmentCourse>?> GetDepartmentCoursesAsync(string DepartmentName);
        Task<ICollection<DepartmentCourse>?> GetDepartmentSemesterCoursesAsync(string DepartmentName, string Type, int Semester);
        Task<ICollection<DepartmentCourse>?> GetDepartmentSemesterCoursesRangeAsync(string DepartmentName, string Type, int lowerBound, int upperBound);
        Task<ICollection<DepartmentCourse>?> GetOverHeadDepCourses(string DepartmentName, string Type, int semester);
        Task<DepartmentCourse?> GetDeparmentCourseAsync(string CourseName, string DepartmentName);
        Task<DepartmentCourse?> GetDeparmentCourseByCourseCodeAsync(string CourseCode);
        Task<DepartmentCourse?> AddCourseToDepAsync(DepartmentCourse course);
        Task<DepartmentCourse?> UpdateDepsCourseAsync(DepartmentCourse course);
        Task<DepartmentCourse?> DeleteCourseFromDepAsync(string CourseName, string DepartmentName);
    }
}