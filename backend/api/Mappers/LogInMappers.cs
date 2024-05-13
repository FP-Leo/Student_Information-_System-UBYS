using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using api.Models;
using api.DTO.loginDtos;

namespace api.Mappers
{
    public static class LogInMappers
    {
        public static LogInInfoDto ToLogInInfoDto(this LogInInfo loginModel){
            return new LogInInfoDto{
                TC = loginModel.TC,
                Password = loginModel.Password,
                UserId = loginModel.UserId,
            };
        }

        public static LogInInfo ToLogInInfo(this LogInInfoPostDto liiDtoModel){
            return new LogInInfo{
                TC = liiDtoModel.TC,
                Password = liiDtoModel.Password,
                UserId = liiDtoModel.UserId
            };
        }

    }
}