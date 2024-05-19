using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class AdvisorAccount : UserAccount
    {
        public int AdvisorSSN { get; set; }

    }
}