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
    public class LecturerAccountRepository : ILecturerAccountRepository
    {
        ApplicationDBContext _context;
        public LecturerAccountRepository(ApplicationDBContext context){
            _context = context;
        }
        public async Task<LecturerAccount?> CreateLecturerAccountAsync(LecturerAccount LecturerAccount)
        {
            await _context.AddAsync(LecturerAccount);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return LecturerAccount;
        }

        public async Task<LecturerAccount?> DeleteLecturerAccountAsync(LecturerAccount LecturerAccount)
        {
            _context.LecturerAccounts.Remove(LecturerAccount);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return LecturerAccount;
        }

        public async Task<LecturerAccount?> GetLecturerAccountBySSNAsync(int LecturerSSN)
        {
            var account = await _context.LecturerAccounts.FirstOrDefaultAsync(la => la.LecturerSSN == LecturerSSN);

            return account;
        }

        public async Task<LecturerAccount?> GetLecturerAccountByTCAsync(string TC)
        {
            var account = await _context.LecturerAccounts.FirstOrDefaultAsync(la => la.User.UserName == TC);

            return account;
        }

        public async Task<LecturerAccount?> GetLecturerAccountByUIDAsync(string UserId)
        {
            var account = await _context.LecturerAccounts.FirstOrDefaultAsync(la => la.UserId == UserId);

            return account;
        }

        public async Task<LecturerAccount?> UpdateLecturerAccountAsync(LecturerAccount LecturerAccount)
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return LecturerAccount;
        }
    }
}