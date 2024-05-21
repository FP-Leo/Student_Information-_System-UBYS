using System.ComponentModel.DataAnnotations;

namespace api.DTO.DepartmentCourse
{
    public class DepartmentCourseDto
    {
        [Required]
        [Range(1, 8, ErrorMessage = "There are only 8 semesters.")]
        public int TaughtSemester { get; set; }
        //Foreign Keys
        [Required]
        public string? CourseName { get; set; } 
        [Required]
        public string? DepartmentName { get; set; }
    }
}