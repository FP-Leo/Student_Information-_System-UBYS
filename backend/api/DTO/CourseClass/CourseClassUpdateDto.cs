
using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseClass
{
    public class CourseClassUpdateDto
    {
        [Required]
        public string? CourseCode { get; set; }
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