using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo
{
    public class StudentAccountDto
    {
        [Required]
        public string? TC {get; set;}
        [Required]
        public string? FirstName {get; set;}
        [Required]
        public string? LastName {get; set;}
        [Required]
        public DateTime BirthDate {get; set;}
        [Required]
        public int SSN {get; set;}
        [Required]
        public DateTime RegisterDate {get; set;}
        [Required]
        public string? CurrentType { get; set; }
        [Required]
        public string? CurrentStatus { get; set; }
        [Required]
        public string? SchoolMail {get; set;}
        public string? PersonalMail {get; set;}
        public string? Phone {get; set;}
    }
}