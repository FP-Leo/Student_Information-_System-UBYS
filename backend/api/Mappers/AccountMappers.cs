using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.AccountInfo;
using api.Models;

namespace api.Mappers
{
    public static class AccountMappers
    {
        public static StudentAccountDto ToStudentAccountDto(this StudentAccount studentAcc){
            return new StudentAccountDto{
                FirstName = studentAcc.FirstName,
                LastName = studentAcc.LastName,
                BirthDate = studentAcc.BirthDate,
                SSN = studentAcc.SSN,
                RegisterDate = studentAcc.RegisterDate,
                CurrentType = studentAcc.CurrentType,
                CurrentStatus = studentAcc.CurrentStatus,
                SchoolMail = studentAcc.SchoolMail,
                Phone = studentAcc.Phone
            };
        }
    }
}