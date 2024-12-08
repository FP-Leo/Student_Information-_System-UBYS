using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.CourseClassDate
{
    public class CourseClassDateDeleteDto
    {
        [Required]
        public string? CourseCode { get; set; }
        [Required]
        public int SchoolYear { get; set; }
        [Required]
        public string? Day { get; set; }
        [Required]
        public TimeOnly Time { get; set; }
        [Required]
        public int NumberOfClasses { get; set; }
    }
}