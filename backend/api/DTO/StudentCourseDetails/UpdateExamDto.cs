
using System.ComponentModel.DataAnnotations;

namespace api.DTO.StudentCourseDetails
{
    public class UpdateExamDto
    {
        [Required]
        public String? CourseCode { get; set;}
        [Required]
        public String? TC { get; set; }
        [Required]
        public String? State { get; set;}
        [Required]
        public int? Points { get; set; }
    }
}