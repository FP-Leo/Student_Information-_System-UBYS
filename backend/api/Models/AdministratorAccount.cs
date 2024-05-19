using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class AdministratorAccount : UserAccount
    {
        public int AdministratorSSN {get; set;}

    }
}