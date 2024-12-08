using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.Course
{
    public class CourseDto
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public string? CourseName { get; set; }
    }
}