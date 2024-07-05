using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class AdvisorAccount : UserAccount
    {
        public AdvisorAccount(){}
        public AdvisorAccount(string[] userAccountData, string[] advisorAccData): base(userAccountData){
            AdvisorId = Int32.Parse(advisorAccData[0]);
        }
        [Required]
        [Column(Order = 6)]
        public int AdvisorId { get; set; }

    }
}