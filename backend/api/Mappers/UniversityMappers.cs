using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.University;
using api.Models;

namespace api.Mappers
{
    public static class UniversityMappers
    {
        public static UniversityDto ToUniversityDto(this University university){
            return new UniversityDto{
                UniversityId = university.UniversityId,
                Name = university.Name,
                Address = university.Address,
                WebSite = university.WebSite,
                Mail = university.Mail,
                PhoneNumber = university.PhoneNumber,
                CurrentSchoolYear = university.CurrentSchoolYear,
                RectorId = university.RectorId
            };
        }
        public static University ToUniversity(this UniversityDto universityDto){
            return new University{
                UniversityId = universityDto.UniversityId,
                Name = universityDto.Name,
                Address = universityDto.Address,
                WebSite = universityDto.WebSite,
                Mail = universityDto.Mail,
                PhoneNumber = universityDto.PhoneNumber,
                CurrentSchoolYear = universityDto.CurrentSchoolYear,
                RectorId = universityDto.RectorId
            };
        }
        public static University ToUniversity(this UniversityPostDto universityPostDto){
             return new University{
                Name = universityPostDto.Name,
                Address = universityPostDto.Address,
                WebSite = universityPostDto.WebSite,
                Mail = universityPostDto.Mail,
                PhoneNumber = universityPostDto.PhoneNumber,
                CurrentSchoolYear = universityPostDto.CurrentSchoolYear,
                RectorId = universityPostDto.RectorId
            };
        }
        public static University ToUniversity(this UniversityUpdateDto universityUpdateDto){
             return new University{
                UniversityId = universityUpdateDto.UniversityId,
                Name = universityUpdateDto.Name,
                Address = universityUpdateDto.Address,
                WebSite = universityUpdateDto.WebSite,
                Mail = universityUpdateDto.Mail,
                PhoneNumber = universityUpdateDto.PhoneNumber,
                CurrentSchoolYear = universityUpdateDto.CurrentSchoolYear,
                RectorId = universityUpdateDto.RectorId
            };
        }
    }
}