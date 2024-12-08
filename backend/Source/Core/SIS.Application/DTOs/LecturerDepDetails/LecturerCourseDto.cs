using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.LecturerDepDetails
{
    public class LecturerCourseDto
    {
        [Required]
        public string? CourseCode { get; set; }
        [Required]
        public string? CourseName { get; set; }
        [Required]
        public string? CourseSemester { get; set; }
        [Required]
        public int SchoolYear { get; set; }
    }
}