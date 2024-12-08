using System.ComponentModel.DataAnnotations;
using SIS.Application.DTOs.ClassDate;

namespace SIS.Application.DTOs.CourseClassDate
{
    public class CourseClassDateDto2
    {
        [Required]
        public string? CourseName { get; set; }
        [Required]
        public ICollection<ClassDateDto>? ClassDates { get; set; }
    }
}