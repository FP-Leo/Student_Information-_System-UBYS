using System.ComponentModel.DataAnnotations;

namespace api.DTO.LecturerDepDetails
{
    public class LecturerDetailedCourseDto
    {
        [Required]
        public String? CourseCode { get; set; }
        [Required]
        public String? CourseName { get; set; }
        [Required]
        public String? Department { get; set; }
        [Required]
        public int Kredi { get; set; }
        [Required]
        public int AKTS { get; set; }
    }
}