using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseSelection
{
    public class CourseSelectionPostDto
    {
        [Required]
        public string? DepartmentName { get; set; }
        [Required]
        public string? TC { get; set; }
        [Required]
        public ICollection<SelectedCoursePostDto>? SelectedCourses { get; set; }
    }
}