using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(SSN), IsUnique = true)]
    public class StudentAccount : UserAccount
    {
        [Required]
        public int SSN { get; set; }
        [Required]
        public string? CurrentType { get; set; }
        [Required]
        public string? CurrentStatus { get; set; }
        //public ICollection<StudentDepDetail>? StudentDepDetails { get; set;}
    }
}