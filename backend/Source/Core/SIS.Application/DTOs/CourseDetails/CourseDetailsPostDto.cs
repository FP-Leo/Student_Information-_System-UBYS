using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.CourseDetails
{
    public class CourseDetailsPostDto
    {
        [Required]
        public string? CourseName { get; set; }
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