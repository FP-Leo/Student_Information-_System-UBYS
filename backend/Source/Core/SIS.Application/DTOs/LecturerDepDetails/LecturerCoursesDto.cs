using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.LecturerDepDetails
{
    public class LecturerCoursesDto
    {
        [Required]
        public string? CourseFaculty { get; set; }
        [Required]
        public string? CourseDepartment { get; set; }
        [Required]
        public ICollection<LecturerCourseDto>? Courses { get; set; }
    }
}