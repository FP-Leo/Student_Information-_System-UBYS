using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class UserAccount
    {
        [Key]
        public int AccountId {get; set;}
        public string FirstName {get; set;} = string.Empty;
        public string LastName {get; set;} = string.Empty;
        public DateTime BirthDate {get; set;}
        public DateTime RegisterDate {get; set;}
        public string SchoolMail {get; set;} = string.Empty;
        //public string PersonalMail {get; set;} = string.Empty; To be added tomorrow
        public string Phone {get; set;} = string.Empty;
        public string UserId {get; set;}
        public User User {get; set;}
    }
}