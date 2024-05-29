using System.ComponentModel.DataAnnotations;

namespace api.DTO.DepartmentCourse
{
    public class DepartmentCourseDto
    {
        [Required]
        public string? DepartmentName { get; set; }
        [Required]
        public string? CourseName { get; set; } 
        [Required]
        [Range(1, 8, ErrorMessage = "There are only 8 semesters.")]
        public int TaughtSemester { get; set; }   
        [Required]
        public String? CourseCode { get; set; }  
        [Required]
        public string? Status { get; set; } 
        [Required]
        public int CourseDetailsId { get; set; }
    }
}