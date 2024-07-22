
using System.ComponentModel.DataAnnotations;

namespace api.DTO.StudentCourseDetails
{
    public class UpdateExamDto
    {
        [Required]
        public String? CourseCode { get; set;}
        [Required]
        public int ID { get; set; }
        [Required]
        public int? Points { get; set; }
    }
}