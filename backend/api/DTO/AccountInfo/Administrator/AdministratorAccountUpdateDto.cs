using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo
{
    public class AdministratorAccountUpdateDto
    {
        [Required]
        public string? UserId { get; set; }
        public string? Phone {get; set;}
        public string? PersonalMail {get; set;}
    }
}