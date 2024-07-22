using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo
{
    public class AdvisorAccountDto
    {
        [Required]
        public string? Role {get; set;}
        [Required]
        public string? TC { get; set; }
        [Required]
        public string? FirstName {get; set;}
        [Required]
        public string? LastName {get; set;}
        [Required]
        public DateOnly BirthDate {get; set;}
        [Required]
        public int ID {get; set;}
        [Required]
        public DateOnly RegisterDate {get; set;}
        [Required]
        public string? SchoolMail {get; set;}
        [Required]
        public string? PersonalMail {get; set;}
        public string? Phone {get; set;}
    }
}