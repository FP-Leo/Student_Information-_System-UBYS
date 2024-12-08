using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.StudentCourseDetails
{
    public class StudentCourseDetailsUpdateDto
    {
        [Required]
        public string? CourseCode { get; set; }
        [Required]
        public string? TC { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public bool AttendanceFulfilled { get; set; }
        [Required]
        public int? MidTerm { get; set; }
        [Required]
        public int? Final { get; set; }
        [Required]
        public int? Complement { get; set; }
        [Required]
        public float? Grade { get; set; }
    }
}