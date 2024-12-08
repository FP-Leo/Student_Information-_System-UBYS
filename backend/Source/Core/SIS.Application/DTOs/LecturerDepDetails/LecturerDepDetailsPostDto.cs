using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.LecturerDepDetails
{
    public class LecturerDepDetailsPostDto
    {
        [Required]
        public string? DepartmentName { get; set; }
        [Required]
        public string? TC { get; set; }
        [Required]
        public int HoursPerWeek { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
    }
}