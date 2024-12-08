using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIS.Application.DTOs.ClassDate;
using SIS.Domain.Entities;

namespace SIS.Application.MappingProfiles
{
    public static class ClassDateMapper
    {

        public static ClassDateDto ToClassDateDto(this ClassDate classDate)
        {
            return new ClassDateDto
            {
                Day = classDate.Day,
                Time = classDate.Time,
                NumberOfClasses = classDate.NumberOfClasses
            };
        }
        public static ClassDate ToClassDate(this ClassDatePostDto classDatePostDto)
        {
            return new ClassDate
            {
                Day = classDatePostDto.Day,
                Time = classDatePostDto.Time,
                NumberOfClasses = classDatePostDto.NumberOfClasses
            };
        }
    }
}