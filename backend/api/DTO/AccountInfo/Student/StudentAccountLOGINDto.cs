using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo
{
    public class StudentAccountLOGINDto
    {
        [Required]
        public string? Token { get; set; }
        [Required]
        public StudentAccountDto? Data { get; set; }
    }
}