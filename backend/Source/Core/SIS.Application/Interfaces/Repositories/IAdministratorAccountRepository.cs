using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface IAdministratorAccountRepository
    {
        Task<AdministratorAccount?> GetAdministratorAccountByTCAsync(string TC);
        Task<AdministratorAccount?> GetAdministratorAccountByIdAsync(int ID);
        Task<AdministratorAccount?> CreateAdministratorAccountAsync(AdministratorAccount AdministratorAccount);
        Task<AdministratorAccount?> UpdateAdministratorAccountAsync(AdministratorAccount AdministratorAccount);
        Task<AdministratorAccount?> DeleteAdministratorAccountAsync(AdministratorAccount AdministratorAccount);
    }
}