using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.loginDtos
{
    public class LogInInfoPutDto
    {
        [Required]
        public int UserId {get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be atleast 8 characters!")]
        public String? OldPassword {get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be atleast 8 characters!")]
        public String? NewPassword {get; set; }
    }
}