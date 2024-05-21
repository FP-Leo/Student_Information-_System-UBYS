using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ILecturerAccountRepository
    {
        Task<LecturerAccount?> GetLecturerAccountByTCAsync(string TC);
        Task<LecturerAccount?> CreateLecturerAccountAsync(LecturerAccount LecturerAccount);
        Task<LecturerAccount?> UpdateLecturerAccountAsync(LecturerAccount LecturerAccount);
        Task<LecturerAccount?> DeleteLecturerAccountAsync(LecturerAccount LecturerAccount);
    }
}