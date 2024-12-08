
using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.SemesterDetails
{
    public class SemesterDetailsDto
    {
        [Required]
        public string? DepartmentName { get; set; }
        [Required]
        public int AcademicYear { get; set; }
        [Required]
        public int Semester { get; set; }
        [Required]
        public int NumberOfObligatoryCourses { get; set; }
        [Required]
        public int NumberOfSelectiveCourses { get; set; }
        [Required]
        public int SelectiveCourseACTS { get; set; }
        [Required]
        public int SelectiveCourseKredi { get; set; }
        [Required]
        public int TotalCourses { get; set; }
    }
}