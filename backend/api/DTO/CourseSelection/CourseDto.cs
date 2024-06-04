using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseSelection
{
    public class CourseDto
    {
        [Required]
        public String? CourseCode { get; set; }
        [Required]
        public String? CourseName { get; set; }
        [Required]
        public int Kredi { get; set; }
        [Required]
        public int AKTS { get; set; }
        [Required]
        public float? Grade { get; set; }
        public String? SemesterYear { get; set; }
    }
}