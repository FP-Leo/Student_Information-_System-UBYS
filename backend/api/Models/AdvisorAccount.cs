using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class AdvisorAccount : UserAccount
    {
        [Required]
        [Column(Order = 6)]
        public int AdvisorId { get; set; }

    }
}