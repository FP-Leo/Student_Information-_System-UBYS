using System.ComponentModel.DataAnnotations;

namespace api.DTO.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public String? Role { get; set; }    
    }
}