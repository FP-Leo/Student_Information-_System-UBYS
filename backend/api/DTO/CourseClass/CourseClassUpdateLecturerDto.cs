using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseClass
{
    public class CourseClassUpdateLecturerDto
    {
        [Required]
        public int LecturerId { get; set; }
        [Required]
        public List<String>? CourseCodes { get; set; }
    }
}