using System.ComponentModel.DataAnnotations;
using api.DTO.ClassDate;

namespace api.DTO.CourseClassDate
{
    public class CourseClassDateDto2
    {
        [Required]
        public string? CourseName { get; set; }
        [Required]
        public ICollection<ClassDateDto>? ClassDates{ get; set; }
    }
}