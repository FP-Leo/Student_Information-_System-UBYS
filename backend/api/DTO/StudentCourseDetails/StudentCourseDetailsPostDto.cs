using System.ComponentModel.DataAnnotations;

namespace api.DTO.StudentCourseDetails
{
    public class StudentCourseDetailsPostDto
    {
        [Required]
        public String? DepartmentName { get; set; }
        [Required]
        public String? CourseName { get; set; }
        [Required]
        public String? TC { get; set; }
    }
}