using System.ComponentModel.DataAnnotations;

namespace api.DTO.LecturerDepDetails
{
    public class LecturerCourseDto
    {
        [Required]
        public String? CourseCode { get; set; }
        [Required]
        public String? CourseName { get; set; }
        [Required]
        public String? CourseSemester { get; set; }
        [Required]
        public int SchoolYear { get; set; }
    }
}