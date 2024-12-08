using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.StudentCourseDetails
{
    public class StudentCourseDetailsDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? CourseCode { get; set; }
        [Required]
        public string? CourseName { get; set; }
        [Required]
        public int? Semester { get; set; }
        [Required]
        public int SchoolYear { get; set; }
        [Required]
        public string? TC { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public bool? AttendanceFulfilled { get; set; }
        [Required]
        public DateTime? MidTermAnnouncment { get; set; }
        [Required]
        public int? MidTerm { get; set; }
        [Required]
        public DateTime? FinalAnnouncment { get; set; }
        [Required]
        public int? Final { get; set; }
        [Required]
        public bool? ComplementRight { get; set; }
        [Required]
        public DateTime? ComplementAnnouncment { get; set; }
        [Required]
        public int? Complement { get; set; }
        [Required]
        public float? Grade { get; set; }
    }
}