using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class CourseDetails
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        public string? CourseLanguage { get; set; }
        public string? CourseLevel { get; set; }
        public string? CourseType { get; set; }
        public string? CourseContent { get; set; }
        [Column(Order = 1)]
        public string? CourseName { get; set; }
        // Navigation Property
        public ICollection<DepartmentCourse>? DepartmentCourses { get; set; } // One-to-Many relationship
    }
}