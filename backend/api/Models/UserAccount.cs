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
        [Column(Order = 0)]
        [Key]
        public int AccountId {get; set;}
        [Required]
        [Column(Order = 2)]
        public string? FirstName {get; set;}
        [Required]
        [Column(Order = 3)]
        public string? LastName {get; set;}
        [Required]
        [Column(Order = 4)]
        public DateOnly BirthDate {get; set;}
        [Column(Order = 5)]
        [Required]
        public DateOnly RegisterDate {get; set;}
        [Required]
        public string? SchoolMail {get; set;}
        public string? PersonalMail {get; set;}
        public string? Phone {get; set;}
        [Column(Order = 1)]
        public string? TC {get; set;}
        public User? User {get; set;}
    }
}