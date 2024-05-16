using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.loginDtos;
using api.Models;

namespace api.Interfaces
{
    public interface ILogInInfoRepository
    {
        //Task<IEnumerable<LogInInfoDto>> GetAllLogInInfoAsync();
        Task<LogInInfo?> GetLogInInfoAsyncByUserId(int UserId);
        
        //Task<LogInInfo?> CreateLogInInfoAsync(LogInInfo logInInfo);
        //Task<LogInInfo?> DeleteLogInInfoAsync(LogInInfo logInInfo);
        Task<LogInInfoDto?> UpdatePasswordAsync(LogInInfo logInInfo, String NewPassword);
    }
}