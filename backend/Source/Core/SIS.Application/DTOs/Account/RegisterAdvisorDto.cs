using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.Account
{
    public class RegisterAdvisorDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Please enter a valid 9-digit number.")]
        public int AdvisorId { get; set; }
        //[Required]
        //public string? CurrentType { get; set; }
        //[Required]
        //public string? CurrentStatus { get; set; }
        [Required]
        public string? SchoolMail { get; set; }
        public string? PersonalMail { get; set; }
        public string? Phone { get; set; }
    }
}