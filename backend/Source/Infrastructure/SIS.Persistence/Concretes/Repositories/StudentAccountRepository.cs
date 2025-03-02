using Microsoft.EntityFrameworkCore;
using SIS.Application.Interfaces.Repositories;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Contexts.Data;

namespace SIS.Persistence.Concretes.Repositories
{
    public class StudentAccountRepository : IStudentAccountRepository
    {
        private readonly ApplicationDBContext _context;
        public StudentAccountRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<StudentAccount?> CreateStudentAccountAsync(StudentAccount studentAccount)
        {
            await _context.AddAsync(studentAccount);

            var result = await _context.SaveChangesAsync();

            if (result <= 0)
                return null;
            return studentAccount;
        }

        public async Task<StudentAccount?> DeleteStudentAccountAsync(StudentAccount studentAccount)
        {
            _context.StudentAccounts.Remove(studentAccount);
            var res = await _context.SaveChangesAsync();
            if (res > 0)
            {
                return studentAccount;
            }
            return null;
        }

        public async Task<ICollection<StudentAccount>?> GetAllActiveStudents()
        {
            var accounts = await _context.StudentAccounts.ToListAsync();

            return accounts;
        }

        public async Task<StudentAccount?> GetStudentAccountByIDAsync(int ID)
        {
            var account = await _context.StudentAccounts.FirstOrDefaultAsync(sa => sa.ID == ID);

            return account;
        }

        public async Task<StudentAccount?> GetStudentAccountByTCAsync(string TC)
        {
            var account = await _context.StudentAccounts.FirstOrDefaultAsync(sa => sa.TC == TC);

            return account;
        }

        public async Task<StudentAccount?> UpdateStudentAccountAsync(StudentAccount studentAccount)
        {
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return studentAccount;
            }
            return null;
        }
    }
}