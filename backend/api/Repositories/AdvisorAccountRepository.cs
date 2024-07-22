using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories
{
    public class AdvisorAccountRepository : IAdvisorAccountRepository
    {
        private readonly ApplicationDBContext _context;
        public AdvisorAccountRepository(ApplicationDBContext context){
            _context = context;
        }
        public async Task<AdvisorAccount?> CreateAdvisorAccountAsync(AdvisorAccount AdvisorAccount)
        {
            await _context.AddAsync(AdvisorAccount);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return AdvisorAccount;
        }

        public async Task<AdvisorAccount?> DeleteAdvisorAccountAsync(AdvisorAccount AdvisorAccount)
        {
            _context.AdvisorAccounts.Remove(AdvisorAccount);
            var res = await _context.SaveChangesAsync();
            if(res <= 0){
                return null;
            }
            return AdvisorAccount;
        }

        public async Task<AdvisorAccount?> GetAdvisorAccountByIdAsync(int ID)
        {
            var account = await _context.AdvisorAccounts.FirstOrDefaultAsync(a => a.ID == ID);

            return account;
        }

        public async Task<AdvisorAccount?> GetAdvisorAccountByTCAsync(string TC)
        {
            var account = await _context.AdvisorAccounts.FirstOrDefaultAsync(a => a.TC == TC);

            return account;
        }

        public async Task<AdvisorAccount?> UpdateAdvisorAccountAsync(AdvisorAccount AdvisorAccount)
        {
            var result = await _context.SaveChangesAsync();
            if(result <= 0){
                return null;
            }
            return AdvisorAccount;
        }
    }
}