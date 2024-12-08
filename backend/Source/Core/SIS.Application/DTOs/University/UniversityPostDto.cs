using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.University
{
    public class UniversityPostDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Mail { get; set; }
        [Required]
        public string? WebSite { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public int CurrentSchoolYear { get; set; }
        [Required]
        public string? RectorTC { get; set; }
    }
}