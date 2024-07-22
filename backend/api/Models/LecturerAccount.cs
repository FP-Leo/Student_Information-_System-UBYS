using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class LecturerAccount : UserAccount
    {
        public LecturerAccount(){}
        public LecturerAccount(string[] userAccountData, string[] lecAccData): base(userAccountData){
            Title = lecAccData[0];
            TotalWorkHours = Int32.Parse(lecAccData[1]);
            CurrentStatus = lecAccData[2];
        }
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