using System.ComponentModel.DataAnnotations;

namespace api.DTO.StudentCourseDetails
{
    public class StudentCourseDetailsUpdateDto
    {
        [Required]
        public String? DepartmentName { get; set; }
        [Required]
        public String? CourseName { get; set; }
        [Required]
        public String? TC { get; set; }
        [Required]
        public String? State { get; set;}
        [Required]
        public bool AttendanceFulfilled { get; set; }
        [Required]
        public float? MidTerm { get; set; }
        [Required]
        public float? Final { get; set; }
        [Required]
        public float? Grade { get; set; }
    }
}