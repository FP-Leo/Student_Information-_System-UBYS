using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTO.loginDtos;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class LogInInfoRepository : ILogInInfoRepository
    {
        ApplicationDBContext _context;
        public LogInInfoRepository(ApplicationDBContext context){
            _context = context;
        }
        /*public async Task<IEnumerable<LogInInfoDto>> GetAllLogInInfoAsync()
        {
            return _context.LogInInfos.ToList().Select(l => l.ToLogInInfoDto());
        }*/

        public async Task<LogInInfo?> GetLogInInfoAsyncByUserId(int UserId)
        {
            //var logInInfo = await _context.LogInInfos.FirstOrDefaultAsync((l => l.UserId == UserId));
            
            return null;
        }
        /*
        public async Task<LogInInfo?> CreateLogInInfoAsync(LogInInfo logInInfo)
        {
            await _context.AddAsync(logInInfo);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return logInInfo;
        }
        */
        public async Task<LogInInfoDto?> UpdatePasswordAsync(LogInInfo logInInfo, String NewPassword)
        {
            logInInfo.Password = NewPassword;
            var result = await _context.SaveChangesAsync();
            if(result > 0){
                return logInInfo.ToLogInInfoDto();
            }
            return null;
        }
        /*
        public async Task<LogInInfo?> DeleteLogInInfoAsync(LogInInfo logInInfo)
        {
            _context.LogInInfos.Remove(logInInfo);
            var res = await _context.SaveChangesAsync();
            if(res > 0){
                return logInInfo;
            }
            return null;
        }
        */
    }
}