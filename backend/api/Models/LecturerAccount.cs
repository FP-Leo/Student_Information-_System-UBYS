using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(LecturerId), IsUnique = true)]
    public class LecturerAccount : UserAccount
    {
        [Required]
        public int LecturerId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public float TotalWorkHours { get; set; }
        [Required]
        public string? CurrentStatus { get; set; }
    }
}