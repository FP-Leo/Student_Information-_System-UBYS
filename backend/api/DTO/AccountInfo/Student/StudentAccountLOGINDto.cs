using System.ComponentModel.DataAnnotations;
using api.DTO.AccountInfo.Student;

namespace api.DTO.AccountInfo
{
    public class StudentAccountLOGINDto
    {
        [Required]
        public string? Token { get; set; }
        [Required]
        public StudentAccountDataDto? Data { get; set; }
    }
}