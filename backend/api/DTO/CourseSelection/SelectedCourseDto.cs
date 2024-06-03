using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseSelection
{
    public class SelectedCourseDto
    {
        [Required]
        public string? CourseCode { get; set; }
        [Required]
        public string? CourseType { get; set; }
        [Required]
        public int ATKS { get; set; }
        [Required]
        public int Kredi { get; set; }
        [Required]
        public int TaughtSemester { get; set; }
        [Required]
        public String? LecturerTC { get; set; }
    }
}