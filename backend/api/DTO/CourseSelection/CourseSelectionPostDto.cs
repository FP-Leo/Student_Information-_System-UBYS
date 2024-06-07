using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseSelection
{
    public class CourseSelectionPostDto
    {
        [Required]
        public string? DepartmentName { get; set; }
        [Required]
        public List<String>? SelectedCoursesCodes { get; set; }
    }
}