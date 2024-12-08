using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.Course
{
    public class CoursePostDto
    {
        [Required]
        public string? CourseName { get; set; }
    }
}