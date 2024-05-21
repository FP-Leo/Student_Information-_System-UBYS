using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseDetails
{
    public class CourseDetailsPostDto
    {
        [Required]
        public string? DepartmentName { get; set; } // Foreign Key
        [Required]
        public string? CourseName { get; set; } // Foreign Key
        [Required]
        public string? CourseLanguage { get; set; }
        [Required]
        public string? CourseLevel { get; set; }
        [Required]
        public string? CourseType { get; set; }
        [Required]
        public string? CourseContent { get; set; }
    }
}