
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(DepartmentName), nameof(TC), nameof(CourseCode),IsUnique = true)]
    public class StudentCourseSelect
    {
        public int Id { get; set; }
        public string? DepartmentName { get; set; }
        public string? TC { get; set; }
        public string? CourseCode { get; set; }
        public StudentCourseSelection? StudentCourseSelection { get; set; }
    }
}