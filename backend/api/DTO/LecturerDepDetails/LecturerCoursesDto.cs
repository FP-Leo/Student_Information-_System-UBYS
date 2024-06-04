using System.ComponentModel.DataAnnotations;

namespace api.DTO.LecturerDepDetails
{
    public class LecturerCoursesDto
    {
        [Required]
        public String? CourseFaculty { get; set; }
        [Required]
        public String? CourseDepartment { get; set; }
        [Required]
        public ICollection<LecturerCourseDto>? Courses { get; set; }
    }
}