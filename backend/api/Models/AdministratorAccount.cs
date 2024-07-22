using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class AdministratorAccount : UserAccount
    {
        public AdministratorAccount(){}
        public AdministratorAccount(string[] userAccountData): base(userAccountData){
        }
    }
}