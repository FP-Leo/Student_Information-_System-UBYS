
using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.StudentCourseDetails
{
    public class StudentDto
    {
        [Required]
        public string? StudentName { get; set; }
        [Required]
        public int ID { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public bool? AttendanceFulfilled { get; set; }
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