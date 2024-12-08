using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.StudentCourseDetails
{
    public class ExamResultDto
    {
        [Required]
        public string? ExamName { get; set; }
        [Required]
        public DateTime? AnnouncmentDate { get; set; }
        [Required]
        public int? Points { get; set; }
        [Required]
        public float ClassAverage { get; set; }
    }
}