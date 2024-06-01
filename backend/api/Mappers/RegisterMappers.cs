using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.Account;
using api.Models;

namespace api.Mappers
{
    public static class RegisterMappers
    {
        public static StudentAccount ToStudentAccount(this RegisterStudentDto registerStudentDto, string id){
            return new StudentAccount{
                FirstName = registerStudentDto.FirstName,
                LastName = registerStudentDto.LastName,
                BirthDate = registerStudentDto.BirthDate,
                SSN = registerStudentDto.SSN,
                RegisterDate = DateOnly.FromDateTime(DateTime.Now),
                CurrentType = registerStudentDto.CurrentType,
                CurrentStatus = registerStudentDto.CurrentStatus,
                SchoolMail = registerStudentDto.SchoolMail,
                PersonalMail = registerStudentDto.PersonalMail,
                Phone = registerStudentDto.Phone,
                TC = id
            };
        }

        public static LecturerAccount ToLecturerAccount(this RegisterLecturerDto registerLecturerDto, string id){
            return new LecturerAccount{
                FirstName = registerLecturerDto.FirstName,
                LastName = registerLecturerDto.LastName,
                BirthDate = registerLecturerDto.BirthDate,
                LecturerId = registerLecturerDto.LecturerId,
                RegisterDate = DateOnly.FromDateTime(DateTime.Now),
                Title = registerLecturerDto.Title,
                TotalWorkHours = 0,
                CurrentStatus = registerLecturerDto.CurrentStatus,
                SchoolMail = registerLecturerDto.SchoolMail,
                PersonalMail = registerLecturerDto.PersonalMail,
                Phone = registerLecturerDto.Phone,
                TC = id
            };
        }
        public static AdvisorAccount ToAdvisorAccount(this RegisterAdvisorDto registerAdvisorDto, string id){
            return new AdvisorAccount{
                FirstName = registerAdvisorDto.FirstName,
                LastName = registerAdvisorDto.LastName,
                BirthDate = registerAdvisorDto.BirthDate,
                AdvisorId = registerAdvisorDto.AdvisorId,
                RegisterDate = DateOnly.FromDateTime(DateTime.Now),
                SchoolMail = registerAdvisorDto.SchoolMail,
                PersonalMail = registerAdvisorDto.PersonalMail,
                Phone = registerAdvisorDto.Phone,
                TC = id
            };
        }
         public static AdministratorAccount ToAdministratorAccount(this RegisterAdministratorDto registerAdministratorDto, string id){
            return new AdministratorAccount{
                FirstName = registerAdministratorDto.FirstName,
                LastName = registerAdministratorDto.LastName,
                BirthDate = registerAdministratorDto.BirthDate,
                AdministratorId = registerAdministratorDto.AdministratorId,
                RegisterDate = DateOnly.FromDateTime(DateTime.Now),
                SchoolMail = registerAdministratorDto.SchoolMail,
                PersonalMail = registerAdministratorDto.PersonalMail,
                Phone = registerAdministratorDto.Phone,
                TC = id
            };
        }

    }
}