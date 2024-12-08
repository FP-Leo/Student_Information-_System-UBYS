
using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.StudentCourseDetails
{
    public class ExamResultsDto
    {
        [Required]
        public string? LecturerName { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public float? Grade { get; set; }
        [Required]
        public ICollection<ExamResultDto>? ExamResultDtos { get; set; }
    }
}