
using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseClass
{
    public class CourseClassDto
    {
        [Required]
        public int CourseClassID { get; set; } // Primary Key
        [Required]
        public string? CourseCode { get; set; }
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
        public int MidTermValue { get; set; }
        [Required]
        public int FinalValue { get; set; }
    }
}