
using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseClass
{
    public class CourseClassDto
    {
        [Required]
        public string? CourseClassID { get; set; } // Primary Key
        [Required]
        public string? DepartmentName { get; set; } 
        [Required]
        public string? CourseName { get; set; }
        [Required]
        public int SchoolYear { get; set; }
        [Required]
        public string? LecturerTC { get; set; }
        [Required]
        public int HourPerWeek { get; set; }
        [Required]
        public int AKTS { get; set; }
        [Required]
        public int Kredi { get; set; }
        [Required]
        public float MidTermValue { get; set; }
        [Required]
        public float FinalValue { get; set; }
    }
}