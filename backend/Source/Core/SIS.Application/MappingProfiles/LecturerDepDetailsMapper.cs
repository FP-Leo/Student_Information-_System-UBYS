using SIS.Application.DTOs.LecturerDepDetails;
using SIS.Domain.Entities;

namespace SIS.Application.MappingProfiles
{
    public static class LecturerDepDetailsMapper
    {
        public static LecturerDepDetailsDto ToLecturerDepDetailsDto(this LecturerDepDetails lecturerDepDetailsDto)
        {
            return new LecturerDepDetailsDto
            {
                DepartmentName = lecturerDepDetailsDto.DepartmentName,
                TC = lecturerDepDetailsDto.TC,
                HoursPerWeek = lecturerDepDetailsDto.HoursPerWeek,
                StartDate = lecturerDepDetailsDto.StartDate,
                EndDate = lecturerDepDetailsDto.EndDate
            };
        }

        public static LecturerDepDetails ToLecturerDepDetails(this LecturerDepDetailsPostDto lecturerDepDetailsDto)
        {
            return new LecturerDepDetails
            {
                DepartmentName = lecturerDepDetailsDto.DepartmentName,
                TC = lecturerDepDetailsDto.TC,
                HoursPerWeek = lecturerDepDetailsDto.HoursPerWeek,
                StartDate = lecturerDepDetailsDto.StartDate,
                EndDate = lecturerDepDetailsDto.EndDate
            };
        }
    }
}