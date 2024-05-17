using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
    public enum Role{
        Student = 0,
        Lecturer = 1,
        Advisor = 2,
        Administrator = 3
    }
}