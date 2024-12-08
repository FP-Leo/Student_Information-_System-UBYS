using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.LecturerDepDetails
{
    public class LecturerDetailedCourseDto
    {
        [Required]
        public string? CourseCode { get; set; }
        [Required]
        public string? CourseName { get; set; }
        [Required]
        public string? Department { get; set; }
        [Required]
        public int Kredi { get; set; }
        [Required]
        public int AKTS { get; set; }
    }
}