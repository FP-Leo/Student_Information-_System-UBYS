using api.DTO.ClassDate;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseClassDate
{
    public class CourseClassDatePostDto
    {
        
        [Required]
        public string? CourseCode { get; set; }
        [Required] 
        public int SchoolYear { get; set; }
        [Required]
        public IList<ClassDatePostDto>? ClassDates{ get; set; }
    }
}