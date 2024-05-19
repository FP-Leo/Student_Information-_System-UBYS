using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class AdvisorAccount : UserAccount
    {
        [Required]
        public int AdvisorSSN { get; set; }

    }
}