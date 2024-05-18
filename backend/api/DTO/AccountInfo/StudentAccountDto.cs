using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.AccountInfo
{
    public class StudentAccountDto
    {
        public string FirstName {get; set;} = string.Empty;
        public string LastName {get; set;} = string.Empty;
        public DateTime BirthDate {get; set;}
        public int SSN {get; set;}
        public DateTime RegisterDate {get; set;}
        public string? CurrentType { get; set; }
        public string? CurrentStatus { get; set; }
        public string SchoolMail {get; set;} = string.Empty;
        public string Phone {get; set;} = string.Empty;
    }
}