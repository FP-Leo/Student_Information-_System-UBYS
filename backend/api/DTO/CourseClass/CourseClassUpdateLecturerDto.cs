using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseClass
{
    public class CourseClassUpdateLecturerDto
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public List<String>? CourseCodes { get; set; }
    }
}