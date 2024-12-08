
using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.StudentCourseDetails
{
    public class UpdateExamDto
    {
        [Required]
        public string? CourseCode { get; set; }
        [Required]
        public int ID { get; set; }
        [Required]
        public int? Points { get; set; }
    }
}