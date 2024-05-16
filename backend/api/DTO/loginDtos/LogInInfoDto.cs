using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.loginDtos
{
    public class LogInInfoDto
    {
        [Required]
        [MinLength(11, ErrorMessage = "TC must be 11 characters!")]
        [MaxLength(11, ErrorMessage = "TC must be 11 characters!")]
        public String? TC {get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be atleast 8 characters!")]
        public String? Password {get; set; }
        [Required]
        public int UserId { get; set; }
    }
}