using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.ClassDate
{
    public class ClassDateUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Day { get; set; }
        [Required]
        public TimeOnly Time { get; set; }
        [Required]
        public int NumberOfClasses { get; set; } // Ex if two it's Time + 45, 5 min break, then 45 mins more.

    }
}