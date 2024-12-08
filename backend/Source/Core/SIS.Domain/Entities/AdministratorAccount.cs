using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIS.Domain.Entities
{
    public class AdministratorAccount : UserAccount
    {
        public AdministratorAccount() { }
        public AdministratorAccount(string[] userAccountData) : base(userAccountData)
        {
        }
    }
}