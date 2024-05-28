using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(AdministratorId), IsUnique = true)]
    public class AdministratorAccount : UserAccount
    {
        [Required]
        [Column(Order = 6)]
        public int AdministratorId {get; set;}

    }
}