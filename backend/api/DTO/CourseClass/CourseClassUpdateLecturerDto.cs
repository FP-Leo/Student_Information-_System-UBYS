using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseClass
{
    public class CourseClassUpdateLecturerDto
    {
        [Required]
        public string? DepartmentName { get; set; } 
        [Required]
        public string? CourseName { get; set; }
        [Required]
        public int HourPerWeek { get; set; }
        [Required]
        public string? LecturerTC { get; set; }
    }
}