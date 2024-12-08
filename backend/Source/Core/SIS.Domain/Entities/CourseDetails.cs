using System.ComponentModel.DataAnnotations.Schema;

namespace SIS.Domain.Entities
{
    public class CourseDetails
    {
        public CourseDetails() { }
        public CourseDetails(string[] data)
        {
            CourseName = data[0];
            CourseLanguage = data[1];
            CourseLevel = data[2];
            CourseType = data[3];
            CourseContent = data[4];
        }
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