using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseSelection
{
    public class SemesterDto
    {
        [Required]
        public int Semester { get; set; }
        [Required]
        public ICollection<CourseDto>? Courses { get; set; }
    }
}