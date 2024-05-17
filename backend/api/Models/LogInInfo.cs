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
        public string? TC { get; set; }
        public string? Password  { get; set; }
        public int UserId { get; set; }
        public UserAccount? User{ get; set; }
    }
}