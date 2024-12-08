using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.StudentCourseDetails
{
    public class UpdateAttendanceDto
    {
        [Required]
        public string? CourseCode { get; set; }
        [Required]
        public int ID { get; set; }
        [Required]
        public bool AttendanceFulfilled { get; set; }
    }
}