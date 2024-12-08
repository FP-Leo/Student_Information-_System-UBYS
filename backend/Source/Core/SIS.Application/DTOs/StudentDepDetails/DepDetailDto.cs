using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.StudentDepDetails
{
    public class DepDetailDto
    {
        [Required]
        public string? DepartmentName { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public float? GNO { get; set; }
        [Required]
        public string? State { get; set; }
    }
}