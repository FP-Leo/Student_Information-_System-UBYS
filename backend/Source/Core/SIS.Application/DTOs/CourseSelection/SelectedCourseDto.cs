using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.CourseSelection
{
    public class SelectedCourseDto
    {
        [Required]
        public string? CourseCode { get; set; }
        [Required]
        public string? CourseType { get; set; }
        [Required]
        public int AKTS { get; set; }
        [Required]
        public int Kredi { get; set; }
        [Required]
        public int TaughtSemester { get; set; }
        [Required]
        public string? LecturerTC { get; set; }
    }
}