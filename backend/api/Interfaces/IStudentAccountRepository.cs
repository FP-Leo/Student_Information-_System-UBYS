using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IStudentAccountRepository
    {
        Task<StudentAccount?> GetStudentAccountByTCAsync(string TC);
        Task<StudentAccount?> GetStudentAccountBySSNAsync(int SSN);
        Task<StudentAccount?> CreateStudentAccountAsync(StudentAccount studentAccount);
        Task<StudentAccount?> UpdateStudentAccountAsync(StudentAccount studentAccount);
        Task<StudentAccount?> DeleteStudentAccountAsync(StudentAccount studentAccount);
    }
}