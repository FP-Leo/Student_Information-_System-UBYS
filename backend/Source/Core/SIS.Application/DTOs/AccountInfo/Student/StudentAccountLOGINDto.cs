using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.AccountInfo.Student
{
    public class StudentAccountLOGINDto
    {
        [Required]
        public string? Token { get; set; }
        [Required]
        public StudentAccountDto? Data { get; set; }
    }
}