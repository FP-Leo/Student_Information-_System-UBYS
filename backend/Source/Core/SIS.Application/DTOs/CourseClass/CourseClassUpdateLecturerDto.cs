using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.CourseClass
{
    public class CourseClassUpdateLecturerDto
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public List<string>? CourseCodes { get; set; }
    }
}