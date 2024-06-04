
using System.ComponentModel.DataAnnotations;

namespace api.DTO.StudentCourseDetails
{
    public class ExamResultsDto
    {
        [Required]
        public String? LecturerName { get; set;}
        [Required]
        public String? State { get; set;}
        [Required]
        public float? Grade { get; set; } 
        [Required]
        public ICollection<ExamResultDto>? ExamResultDtos{ get; set; }
    }
}