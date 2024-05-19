using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo
{
    public class LecturerAccountUpdateDto
    {
        [Required]
        public string? UserId { get; set; }
        //Personal Email will be added later.
        public string? Phone {get; set;}
    }
}