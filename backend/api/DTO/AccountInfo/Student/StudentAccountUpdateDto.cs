using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.AccountInfo
{
    public class StudentAccountUpdateDto
    {
        [Required]
        public string? UserId { get; set; }
        public string? Phone {get; set;}
        public string? PersonalMail {get; set;}
    }
}