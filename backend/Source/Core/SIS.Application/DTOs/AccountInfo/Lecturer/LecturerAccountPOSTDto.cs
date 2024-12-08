using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.AccountInfo.Lecturer
{
    public class LecturerAccountPOSTDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        //[RegularExpression("^[0-9]{9}$", ErrorMessage = "Please enter a valid 9-digit number.")] // conditions to be decided.
        public int LecturerId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? CurrentStatus { get; set; }
        [Required]
        public float TotalWorkHours { get; set; }
        [Required]
        public string? SchoolMail { get; set; }
        public string? PersonalMail { get; set; }
        public string? Phone { get; set; }
        [Required]
        public string? TC { get; set; }
    }
}