using System.ComponentModel.DataAnnotations;

namespace api.DTO.Course
{
    public class CoursePostDto
    {
        [Required]
        public String? CourseName { get; set; }
    }
}