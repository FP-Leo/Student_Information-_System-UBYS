
using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.StudentCourseDetails
{
    public class StudentListDto
    {
        [Required]
        public string? DepartmentName { get; set; }
        [Required]
        public string? CourseName { get; set; }
        [Required]
        public string? CourseCode { get; set; }
        [Required]
        public int NumberOfStudents { get; set; }
        [Required]
        public ICollection<StudentDto>? Students { get; set; }
    }
}