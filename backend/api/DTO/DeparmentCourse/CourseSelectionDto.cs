using System.ComponentModel.DataAnnotations;

namespace api.DTO.DeparmentCourse
{
    public class CourseSelectionDto
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