
using System.ComponentModel.DataAnnotations;

namespace api.DTO.StudentCourseDetails
{
    public class StudentDto
    {
        [Required]
        public String? StudentName { get; set; }
        [Required]
        public int SSN { get; set; }
        [Required] 
        public int Year { get; set; }
        [Required]
        public String? State { get; set; }
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