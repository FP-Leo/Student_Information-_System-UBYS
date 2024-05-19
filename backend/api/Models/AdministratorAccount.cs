using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(AdministratorId), IsUnique = true)]
    public class AdministratorAccount : UserAccount
    {
        [Required]
        public int AdministratorId {get; set;}

    }
}