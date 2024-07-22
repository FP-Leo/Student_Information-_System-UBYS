using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(SchoolMail), IsUnique = true)]
    [Index(nameof(PersonalMail), IsUnique = true)]
    [Index(nameof(Phone), IsUnique = true)]
    [Index(nameof(ID), IsUnique = true)]
    public class UserAccount
    {
        public UserAccount(){}
        public UserAccount(string[] data){
            TC = data[0];
            FirstName = data[1];
            LastName = data[2];
            BirthDate = DateOnly.Parse(data[3]);
            RegisterDate = DateOnly.Parse(data[4]);
            ID = Int32.Parse(data[5]);
            if(data[6] != "null"){
                SchoolMail = data[5];
            }else{
                SchoolMail = null;
            }
            if(data[7] != "null"){
                PersonalMail = data[6];
            }else{
                PersonalMail = null;
            }
            if(data[8] != "null"){
                Phone = data[7];
            }else{
                Phone = null;
            }
        }
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
        [Column(Order = 6)]
        [Required]
        public int ID {get; set;}
        [Required]
        public string? SchoolMail {get; set;}
        public string? PersonalMail {get; set;}
        public string? Phone {get; set;}
        [Column(Order = 1)]
        public string? TC {get; set;}
        public User? User {get; set;}
    }
}