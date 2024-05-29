using System.ComponentModel.DataAnnotations;

namespace api.DTO.ClassDate
{
    public class ClassDateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public String? Day { get; set; }
        [Required]
        public DateTime? Time { get; set;}
        [Required]
        public int NumberOfClasses { get; set; } // Ex if two it's Time + 45, 5 min break, then 45 mins more.

        
        
   }
}