using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.CourseClass
{
    public class CourseClassPostWOCodeDto
    {
        [Required]
        public string? DepartmentName { get; set; }
        [Required]
        public string? CourseName { get; set; }
        [Required]
        public string? LecturerTC { get; set; }
        [Required]
        public int HourPerWeek { get; set; }
        [Required]
        public int AKTS { get; set; }
        [Required]
        public int Kredi { get; set; }
        [Required]
        public int MidTermValue { get; set; }
        [Required]
        public int FinalValue { get; set; }
    }
}