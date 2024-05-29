using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseClassDate
{
    public class CourseClassDateDeleteDto
    {
        [Required]
        public string? CourseCode { get; set; }
        [Required]
        public int SchoolYear { get; set; }
        [Required] 
        public string? Day { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public int NumberOfClasses { get; set; }
    }
}