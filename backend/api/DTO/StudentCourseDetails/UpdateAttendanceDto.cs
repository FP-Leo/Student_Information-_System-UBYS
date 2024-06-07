using System.ComponentModel.DataAnnotations;

namespace api.DTO.StudentCourseDetails
{
    public class UpdateAttendanceDto
    {
        [Required]
        public String? CourseCode { get; set;}
        [Required]
        public String? TC { get; set; }
        [Required]
        public bool AttendanceFulfilled { get; set; }
    }
}