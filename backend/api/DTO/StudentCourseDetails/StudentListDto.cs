
using System.ComponentModel.DataAnnotations;

namespace api.DTO.StudentCourseDetails
{
    public class StudentListDto
    {
        [Required]
        public String? DepartmentName { get; set; }
        [Required]
        public String? CourseName { get; set; }
        [Required]
        public String? CourseCode { get; set; }
        [Required]
        public int NumberOfStudents { get; set; }
        [Required]
        public ICollection<StudentDto>? Students{ get; set; }
    }
}