using System.ComponentModel.DataAnnotations;


namespace SIS.Application.DTOs.CourseSelection
{
    public class Transcript
    {
        [Required]
        public StudentInfoDto? StudentInfo { get; set; }
        [Required]
        public DepartmentInfoDto? DepartmentInfo { get; set; }
        [Required]
        public ICollection<SemesterDto>? Semesters { get; set; }
    }
}