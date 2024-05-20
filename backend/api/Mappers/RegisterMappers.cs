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
                RegisterDate = DateTime.Now,
                CurrentType = registerStudentDto.CurrentType,
                CurrentStatus = registerStudentDto.CurrentStatus,
                SchoolMail = registerStudentDto.SchoolMail,
                PersonalMail = registerStudentDto.PersonalMail,
                Phone = registerStudentDto.Phone,
                UserId = id
            };
        }

        public static LecturerAccount ToLecturerAccount(this RegisterLecturerDto registerLecturerDto, string id){
            return new LecturerAccount{
                FirstName = registerLecturerDto.FirstName,
                LastName = registerLecturerDto.LastName,
                BirthDate = registerLecturerDto.BirthDate,
                LecturerId = registerLecturerDto.LecturerId,
                RegisterDate = DateTime.Now,
                Title = registerLecturerDto.Title,
                TotalWorkHours = 0,
                CurrentStatus = registerLecturerDto.CurrentStatus,
                SchoolMail = registerLecturerDto.SchoolMail,
                PersonalMail = registerLecturerDto.PersonalMail,
                Phone = registerLecturerDto.Phone,
                UserId = id
            };
        }
        public static AdvisorAccount ToAdvisorAccount(this RegisterAdvisorDto registerAdvisorDto, string id){
            return new AdvisorAccount{
                FirstName = registerAdvisorDto.FirstName,
                LastName = registerAdvisorDto.LastName,
                BirthDate = registerAdvisorDto.BirthDate,
                AdvisorSSN = registerAdvisorDto.AdvisorId,
                RegisterDate = DateTime.Now,
                //Title = registerAdvisorDto.Title,
                //TotalWorkHours = 0,
                //CurrentStatus = registerAdvisorDto.CurrentStatus,
                SchoolMail = registerAdvisorDto.SchoolMail,
                PersonalMail = registerAdvisorDto.PersonalMail,
                Phone = registerAdvisorDto.Phone,
                UserId = id
            };
        }
         public static AdministratorAccount ToAdministratorAccount(this RegisterAdministratorDto registerAdministratorDto, string id){
            return new AdministratorAccount{
                FirstName = registerAdministratorDto.FirstName,
                LastName = registerAdministratorDto.LastName,
                BirthDate = registerAdministratorDto.BirthDate,
                AdministratorId = registerAdministratorDto.AdministratorId,
                RegisterDate = DateTime.Now,
                //Title = registerAdministratorDto.Title,
                //TotalWorkHours = 0,
                //CurrentStatus = registerAdministratorDto.CurrentStatus,
                SchoolMail = registerAdministratorDto.SchoolMail,
                PersonalMail = registerAdministratorDto.PersonalMail,
                Phone = registerAdministratorDto.Phone,
                UserId = id
            };
        }

    }
}