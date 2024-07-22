using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IAdvisorAccountRepository
    {
        Task<AdvisorAccount?> GetAdvisorAccountByTCAsync(string TC);
        Task<AdvisorAccount?> GetAdvisorAccountByIdAsync(int ID);
        Task<AdvisorAccount?> CreateAdvisorAccountAsync(AdvisorAccount AdvisorAccount);
        Task<AdvisorAccount?> UpdateAdvisorAccountAsync(AdvisorAccount AdvisorAccount);
        Task<AdvisorAccount?> DeleteAdvisorAccountAsync(AdvisorAccount AdvisorAccount);
    }


}
