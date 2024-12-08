using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.CourseSelection
{
    public class CourseSelectionPostDto
    {
        [Required]
        public string? DepartmentName { get; set; }
        [Required]
        public List<string>? SelectedCoursesCodes { get; set; }
    }
}