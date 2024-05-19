using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

         public static StudentAccountLOGINDto ToStudentAccountLOGINDto(this StudentAccount studentAcc){
            return new StudentAccountLOGINDto{
                Role = "Student",
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

        public static StudentAccount POSTToStudentAccount(this StudentAccountPOSTDto newStudentAcc){
            return new StudentAccount{
                FirstName = newStudentAcc.FirstName,
                LastName = newStudentAcc.LastName,
                BirthDate = newStudentAcc.BirthDate,
                SSN = newStudentAcc.SSN,
                RegisterDate = DateTime.Now,
                CurrentType = newStudentAcc.CurrentType,
                CurrentStatus = newStudentAcc.CurrentStatus,
                SchoolMail = newStudentAcc.SchoolMail,
                Phone = newStudentAcc.Phone,
                UserId = newStudentAcc.UserId
            };
        }
    }
}