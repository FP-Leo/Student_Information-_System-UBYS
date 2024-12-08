using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.CourseSelection
{
    public class CourseDto
    {
        [Required]
        public string? CourseCode { get; set; }
        [Required]
        public string? CourseName { get; set; }
        [Required]
        public int Kredi { get; set; }
        [Required]
        public int AKTS { get; set; }
        [Required]
        public float? Grade { get; set; }
        public string? SemesterYear { get; set; }
    }
}