using System.ComponentModel.DataAnnotations;
using SIS.Application.DTOs.ClassDate;

namespace SIS.Application.DTOs.CourseClassDate
{
    public class CourseClassDateDto
    {
        [Required]
        public int Id { get; set; }
        // Foreign Keys
        [Required]
        public string? CourseCode { get; set; }
        [Required]
        public int SchoolYear { get; set; }
        [Required]
        public ICollection<ClassDateDto>? ClassDates { get; set; }
    }
}