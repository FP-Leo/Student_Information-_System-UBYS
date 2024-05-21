using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(SchoolMail), IsUnique = true)]
    [Index(nameof(PersonalMail), IsUnique = true)]
    [Index(nameof(Phone), IsUnique = true)]
    public class UserAccount
    {
        [Key]
        public int AccountId {get; set;}
        [Required]
        public string? FirstName {get; set;}
        [Required]
        public string? LastName {get; set;}
        [Required]
        public DateTime BirthDate {get; set;}
        [Required]
        public DateTime RegisterDate {get; set;}
        [Required]
        public string? SchoolMail {get; set;}
        public string? PersonalMail {get; set;}
        public string? Phone {get; set;}
        public string? TC {get; set;}
        public User? User {get; set;}
    }
}