using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(AdministratorId), IsUnique = true)]
    public class AdministratorAccount : UserAccount
    {
        public AdministratorAccount(){}
        public AdministratorAccount(string[] userAccountData, string[] administatorAccData): base(userAccountData){
            AdministratorId = Int32.Parse(administatorAccData[0]);
        }
        [Required]
        [Column(Order = 6)]
        public int AdministratorId {get; set;}

    }
}