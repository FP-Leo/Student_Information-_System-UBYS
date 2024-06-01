using System.ComponentModel.DataAnnotations;

namespace api.DTO.ClassDate
{
    public class ClassDatePostDto
    {
        
        [Required]
        public String? Day { get; set; }
        [Required]
        public TimeOnly Time { get; set;}
        [Required]
        public int NumberOfClasses { get; set; } // Ex if two it's Time + 45, 5 min break, then 45 mins more.

    }
}