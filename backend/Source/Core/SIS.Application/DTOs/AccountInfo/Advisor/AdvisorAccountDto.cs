using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.AccountInfo.Advisor
{
    public class AdvisorAccountDto
    {
        [Required]
        public string? Role { get; set; }
        [Required]
        public string? TC { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public int AdvisorId { get; set; }
        [Required]
        public DateOnly RegisterDate { get; set; }
        [Required]
        public string? SchoolMail { get; set; }
        [Required]
        public string? PersonalMail { get; set; }
        public string? Phone { get; set; }
    }
}