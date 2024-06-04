using System.ComponentModel.DataAnnotations;

namespace api.DTO.StudentCourseDetails
{
    public class ExamResultDto
    {
        [Required]
        public String? ExamName { get; set;}
        [Required]
        public DateTime? AnnouncmentDate { get; set;}
        [Required]
        public int? Points { get; set;}
        [Required]
        public float ClassAverage { get; set;}
    }
}