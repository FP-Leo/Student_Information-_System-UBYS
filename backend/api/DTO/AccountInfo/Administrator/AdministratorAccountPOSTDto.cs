using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo
{
    public class AdministratorAccountPOSTDto
    {
        [Required]
        public string? TC {get; set;}
        [Required]
        public string FirstName {get; set;} = string.Empty;
        [Required]
        public string LastName {get; set;} = string.Empty;
        [Required]
        public DateTime BirthDate {get; set;}
        [Required]
        //[RegularExpression("^[0-9]{9}$", ErrorMessage = "Please enter a valid 9-digit number.")] // conditions to be decided.
        public int AdministratorId {get; set;}
        [Required]
        public string? SchoolMail {get; set;}
        [Required]
        public string? PersonalMail {get; set;}
        public string? Phone {get; set;}
    }
}