using SIS.Application.DTOs.ClassDate;
using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.CourseClassDate
{
    public class CourseClassDatePostDto
    {

        [Required]
        public string? CourseCode { get; set; }
        [Required]
        public int SchoolYear { get; set; }
        [Required]
        public IList<ClassDatePostDto>? ClassDates { get; set; }
    }
}