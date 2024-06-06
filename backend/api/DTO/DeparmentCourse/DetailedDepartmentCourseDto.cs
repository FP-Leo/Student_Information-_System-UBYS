using System.ComponentModel.DataAnnotations;

namespace api.DTO.DeparmentCourse
{
    public class DetailedDepartmentCourseDto
    {
        [Required]
        public String? CourseCode { get; set; } 
        [Required]
        public string? CourseName { get; set; } 
        [Required]
        public string? FacultyName { get; set; }
        [Required]
        public string? DepartmentName { get; set; }
        [Required]
        public string? Semester { get; set; } 
        [Required]
        public int Kredi { get; set; } 
        [Required]
        public int AKTS { get; set; } 
    }
}