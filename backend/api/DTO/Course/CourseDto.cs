using System.ComponentModel.DataAnnotations;

namespace api.DTO.Course
{
    public class CourseDto
    {
        [Required]
        public int CourseId { get; set; } 
        [Required]
        public string? CourseName { get; set; }
    }
}