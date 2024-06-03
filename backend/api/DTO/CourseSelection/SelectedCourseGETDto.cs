using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseSelection
{
    public class SelectedCourseGETDto
    {
        [Required]
        public String? CourseCode { get; set; }
        [Required]
        public string? CourseName { get; set; } 
        [Required]
        public String? CourseType { get; set; }
        [Required]
        public int AKTS { get; set; }
        [Required]
        public int Kredi { get; set; }
        public String? LecturerName { get; set; }
    }
}