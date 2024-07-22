using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class AdministratorAccountRepository : IAdministratorAccountRepository
    {
        private readonly ApplicationDBContext _context;
        public AdministratorAccountRepository(ApplicationDBContext context){
            _context = context;
        }
        public async Task<AdministratorAccount?> CreateAdministratorAccountAsync(AdministratorAccount AdministratorAccount)
        {
            await _context.AddAsync(AdministratorAccount);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return AdministratorAccount;
        }

        public async Task<AdministratorAccount?> DeleteAdministratorAccountAsync(AdministratorAccount AdministratorAccount)
        {
            _context.AdministratorAccounts.Remove(AdministratorAccount);
            var res = await _context.SaveChangesAsync();
            if(res <= 0){
                return null;
            }
            return AdministratorAccount;
        }

        public async Task<AdministratorAccount?> GetAdministratorAccountByIdAsync(int ID)
        {
            var account = await _context.AdministratorAccounts.FirstOrDefaultAsync(a => a.ID == ID);

            return account;
        }

        public async Task<AdministratorAccount?> GetAdministratorAccountByTCAsync(string TC)
        {
            var account = await _context.AdministratorAccounts.FirstOrDefaultAsync(a => a.TC == TC);

            return account;
        }

        public async Task<AdministratorAccount?> UpdateAdministratorAccountAsync(AdministratorAccount AdministratorAccount)
        {
            var result = await _context.SaveChangesAsync();
             if (result <= 0)
                return null;
            return AdministratorAccount;
        }
    }
}