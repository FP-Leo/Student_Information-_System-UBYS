
using System.ComponentModel.DataAnnotations;

namespace api.DTO.SemesterDetails
{
    public class SemesterDetailsPostDto
    {
        [Required]
        public String? DepartmentName { get; set;}
        [Required]
        public int Semester { get; set;}
        [Required]
        public int NumberOfObligatoryCourses { get; set;}
        [Required]
        public int NumberOfSelectiveCourses { get; set;}
        [Required]
        public int SelectiveCourseACTS { get; set;}
        [Required]
        public int SelectiveCourseKredi { get; set;}
    }
}