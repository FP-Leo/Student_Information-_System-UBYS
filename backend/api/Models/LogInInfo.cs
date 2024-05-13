using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class LogInInfo
    {
        public int Id { get; set; }
        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string TC { get; set; }
        [Required]
        [MinLength(8)]
        public string Password  { get; set; }
        [Required]
        public int UserId { get; set; }
        public User? User{ get; set; }
    }
}