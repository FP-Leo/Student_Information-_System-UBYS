using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo
{
    public class AdvisorAccountLOGINDto
    {
        [Required]
        public string? Role {get; set;}
        [Required]
        public string? FirstName {get; set;}
        [Required]
        public string? LastName {get; set;}
        [Required]
        public DateTime BirthDate {get; set;}
        [Required]
        public int AdvisorId {get; set;}
        [Required]
        public DateTime RegisterDate {get; set;}
        [Required]
        public string? SchoolMail {get; set;}
        public string? PersonalMail {get; set;}
        [Required]
        public string? Phone {get; set;}
    }
}