
using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseSelection
{
    public class CourseSelectionDto
    {
        [Required]
        public string? DepartmentName { get; set; }
        [Required]
        public string? TC { get; set; }
        [Required]
        public DateTime SentDate { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public ICollection<SelectedCourseGETDto>? SelectedCourses { get; set; }
    }
}