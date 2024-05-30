using System.ComponentModel.DataAnnotations;
using api.DTO.ClassDate;

namespace api.DTO.CourseClassDate
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
        public ICollection<ClassDateDto>? ClassDates{ get; set; }
    }
}