using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(LecturerId), IsUnique = true)]
    public class LecturerAccount : UserAccount
    {
        public LecturerAccount(){}
        public LecturerAccount(string[] userAccountData, string[] lecAccData): base(userAccountData){
            LecturerId = Int32.Parse(lecAccData[0]);
            Title = lecAccData[1];
            TotalWorkHours = Int32.Parse(lecAccData[2]);
            CurrentStatus = lecAccData[3];
        }
        [Required]
        [Column(Order = 6)]
        public int LecturerId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public float TotalWorkHours { get; set; }
        [Required]
        public string? CurrentStatus { get; set; }
        // Navigation Properties
        public ICollection<CourseClass>? Courses{ get; set; }
        public ICollection<LecturerDepDetails>? LecturerDepDetails { get; set;}
    }
}