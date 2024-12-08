using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.AccountInfo.Administrator
{
    public class LoginDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}