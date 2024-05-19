using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IAdministratorAccountRepository
    {
        Task<AdministratorAccount?> GetAdministratorAccountByUIDAsync(string UserId);
        Task<AdministratorAccount?> GetAdministratorAccountByTCAsync(string TC);
        Task<AdministratorAccount?> GetAdministratorAccountBySSNAsync(int AdministratorSSN);
        Task<AdministratorAccount?> CreateAdministratorAccountAsync(AdministratorAccount AdministratorAccount);
        Task<AdministratorAccount?> UpdateAdministratorAccountAsync(AdministratorAccount AdministratorAccount);
        Task<AdministratorAccount?> DeleteAdministratorAccountAsync(AdministratorAccount AdministratorAccount);
    }
}