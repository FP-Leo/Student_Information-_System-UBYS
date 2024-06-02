using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseSelection
{
    public class SelectedCoursePostDto
    {
        [Required]
        public string? CourseCode { get; set; }
    }
}