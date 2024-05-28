using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(DepartmentName), nameof(CourseName), nameof(SchoolYear), nameof(ClassDateId), IsUnique = true)]
    public class CourseClassDate
    {
        public int Id { get; set; }
        // Foreign Keys
        public string? DepartmentName { get; set; }
        public string? CourseName { get; set; } 
        public int SchoolYear { get; set; }
        public int ClassDateId { get; set; }
        // Navigation 
        public CourseClass? CourseClass { get; set; }
        public ClassDate? ClassDate { get; set; }
    }
}