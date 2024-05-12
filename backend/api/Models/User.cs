using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class User
    {
        public int Id {get; set;}
        public string FirstName {get; set;} = string.Empty;
        public string LastName {get; set;} = string.Empty;
        public DateTime BirthDate {get; set;}
        public DateTime RegisterDate {get; set;}
        public string SchoolMail {get; set;} = string.Empty;
        public string Phone {get; set;} = string.Empty;
        public int? LogInID {get; set;}
        public LogInInfo? LogInInfo{get; set;}
    }
}