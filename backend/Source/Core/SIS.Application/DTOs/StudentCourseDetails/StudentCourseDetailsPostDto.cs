using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.StudentCourseDetails
{
    public class StudentCourseDetailsPostDto
    {
        [Required]
        public string? DepartmentName { get; set; }
        [Required]
        public string? CourseCode { get; set; }
        [Required]
        public string? TC { get; set; }
    }
}