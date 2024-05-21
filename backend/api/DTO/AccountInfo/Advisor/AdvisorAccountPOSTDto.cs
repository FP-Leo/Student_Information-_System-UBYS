using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo
{
    public class AdvisorAccountPOSTDto
    {
        [Required]
        public string FirstName {get; set;} = string.Empty;
        [Required]
        public string LastName {get; set;} = string.Empty;
        [Required]
        public DateTime BirthDate {get; set;}
        [Required]
        //[RegularExpression("^[0-9]{9}$", ErrorMessage = "Please enter a valid 9-digit number.")] // Conditions to be decided.
        public int AdvisorId {get; set;}
        [Required]
        public string? SchoolMail {get; set;}
        public string? PersonalMail {get; set;}
        public string? Phone {get; set;}
        [Required]
        public string? TC {get; set;}
    }
}