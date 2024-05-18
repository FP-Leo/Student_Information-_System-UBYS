using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StudentAccountRepository : IStudentAccountRepository
    {
        ApplicationDBContext _context;
        public StudentAccountRepository(ApplicationDBContext context){
            _context = context;
        }
        public Task<StudentAccount?> CreateStudentAccountAsync(StudentAccount studentAccount)
        {
            throw new NotImplementedException();
        }

        public Task<StudentAccount?> DeleteStudentAccountByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentAccount?> GetStudentAccountBySSNAsync(int SSN)
        {
            var account = await _context.StudentAccounts.FirstOrDefaultAsync(sa => sa.SSN == SSN);

            return account;
        }

        public async Task<StudentAccount?> GetStudentAccountByTCAsync(string TC)
        {
            var account = await _context.StudentAccounts.FirstOrDefaultAsync(sa => sa.User.UserName == TC);

            return account;
        }

        public Task<StudentAccount?> UpdateStudentAccountAsync(StudentAccount studentAccount)
        {
            throw new NotImplementedException();
        }
    }
}