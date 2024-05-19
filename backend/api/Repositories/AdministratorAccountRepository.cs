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

namespace api.Repositories
{
    public class AdministratorAccountRepository : IAdministratorAccountRepository
    {
        ApplicationDBContext _context;
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

        public async Task<AdministratorAccount?> GetAdministratorAccountBySSNAsync(int AdministratorSSN)
        {
            var account = await _context.AdministratorAccounts.FirstOrDefaultAsync(a => a.AdministratorSSN == AdministratorSSN);

            return account;
        }

        public async Task<AdministratorAccount?> GetAdministratorAccountByTCAsync(string TC)
        {
            var account = await _context.AdministratorAccounts.FirstOrDefaultAsync(a => a.User.UserName == TC);

            return account;
        }

        public async Task<AdministratorAccount?> GetAdministratorAccountByUIDAsync(string UserId)
        {
            var account = await _context.AdministratorAccounts.FirstOrDefaultAsync(a => a.UserId == UserId);

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