using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class StudentAccount : UserAccount
    {
        public int SSN {get; set;}
        public string? CurrentType { get; set; }
        public string? CurrentStatus { get; set; }
    }
}