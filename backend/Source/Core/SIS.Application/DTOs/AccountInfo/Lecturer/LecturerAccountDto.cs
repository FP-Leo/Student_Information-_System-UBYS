using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.AccountInfo.Lecturer
{
    public class LecturerAccountDto
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
        public int LecturerId { get; set; }
        [Required]
        public DateOnly RegisterDate { get; set; }
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
        public ICollection<LecturerDepartmentDto>? Departments { get; set; }
    }
}