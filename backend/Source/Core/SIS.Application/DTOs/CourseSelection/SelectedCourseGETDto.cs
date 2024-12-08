using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.CourseSelection
{
    public class SelectedCourseGETDto
    {
        [Required]
        public string? CourseCode { get; set; }
        [Required]
        public string? CourseName { get; set; }
        [Required]
        public string? CourseType { get; set; }
        [Required]
        public int AKTS { get; set; }
        [Required]
        public int Kredi { get; set; }
        public string? LecturerName { get; set; }
    }
}