using Microsoft.EntityFrameworkCore;
using SIS.Application.Interfaces.Repositories;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Contexts.Data;

namespace SIS.Persistence.Concretes.Repositories
{
    public class LecturerAccountRepository : ILecturerAccountRepository
    {
        private readonly ApplicationDBContext _context;
        public LecturerAccountRepository(ApplicationDBContext context)
        {
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
        public async Task<LecturerAccount?> GetLecturerAccountByIDAsync(int ID)
        {
            var account = await _context.LecturerAccounts.FirstOrDefaultAsync(la => la.ID == ID);

            return account;
        }

        public async Task<LecturerAccount?> GetLecturerAccountByTCAsync(string TC)
        {
            var account = await _context.LecturerAccounts.FirstOrDefaultAsync(la => la.TC == TC);

            return account;
        }

        public async Task<ICollection<LecturerAccount>?> GetLecturerAccounts()
        {
            var accounts = await _context.LecturerAccounts.ToListAsync();

            return accounts;
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