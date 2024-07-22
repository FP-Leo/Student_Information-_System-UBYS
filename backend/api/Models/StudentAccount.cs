using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class StudentAccount : UserAccount
    {
        public StudentAccount(){}
        public StudentAccount(string[] userAccountData, string[] studentAccData): base(userAccountData){
            CurrentType = studentAccData[0];
            CurrentStatus = studentAccData[1];
        }
        [Required]
        public string? CurrentType { get; set; }
        [Required]
        public string? CurrentStatus { get; set; }
        public ICollection<StudentDepDetails>? StudentDepDetails { get; set;}
    }
}