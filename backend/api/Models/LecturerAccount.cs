using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(LecturerId), IsUnique = true)]
    public class LecturerAccount : UserAccount
    {
        [Required]
        [Column(Order = 6)]
        public int LecturerId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public float TotalWorkHours { get; set; }
        [Required]
        public string? CurrentStatus { get; set; }
    }
}