using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(SSN), IsUnique = true)]
    public class StudentAccount : UserAccount
    {
        public StudentAccount(){}
        public StudentAccount(string[] userAccountData, string[] studentAccData): base(userAccountData){
            SSN = Int32.Parse(studentAccData[0]);
            CurrentType = studentAccData[1];
            CurrentStatus = studentAccData[2];
        }
        [Required]
        [Column(Order = 6)]
        public int SSN { get; set; }
        [Required]
        public string? CurrentType { get; set; }
        [Required]
        public string? CurrentStatus { get; set; }
        public ICollection<StudentDepDetails>? StudentDepDetails { get; set;}
    }
}