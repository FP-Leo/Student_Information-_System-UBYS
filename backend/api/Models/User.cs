using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class User : IdentityUser
    {
        public UserAccount? UserAccount{ get; set; }
        public University? University{ get; set; }
        public Faculty? Faculty{ get; set; }
        public Department? Department{ get; set; }
    }
}