using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIS.Domain.Entities
{
    public class AdvisorAccount : UserAccount
    {
        public AdvisorAccount() { }
        public AdvisorAccount(string[] userAccountData) : base(userAccountData)
        {
        }
    }
}