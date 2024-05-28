using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseDetails
{
    public class CourseDetailsUpdateDto
    {
        [Required]
        public int CourseDetailsId { get; set; }
        [Required]
        public string? CourseLanguage { get; set; }
        [Required]
        public string? CourseLevel { get; set; }
        [Required]
        public string? CourseType { get; set; }
        [Required]
        public string? CourseContent { get; set; }
    }
}