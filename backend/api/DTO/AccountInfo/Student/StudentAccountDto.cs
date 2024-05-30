using System.ComponentModel.DataAnnotations;
using api.DTO.AccountInfo.Student;

namespace api.DTO.AccountInfo
{
    public class StudentAccountDto
    {
        [Required]
        public string? Role {get; set;}
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
        [Required]
        public ICollection<StudentDepartmentDto>? Departments {get; set;}
    }
}