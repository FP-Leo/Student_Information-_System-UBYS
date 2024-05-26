using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.ClassDate;
using api.Models;

namespace api.Mappers
{
    public static class ClassDateMapper
    {
        
        public static ClassDateDto ToClassDateDto(this ClassDate classDate){
            return new ClassDateDto{
                Id = classDate.Id,
                Day = classDate.Day,
                Time = classDate.Time,
                NumberOfClasses  = classDate.NumberOfClasses

                };
        } 
        public static ClassDate ToClassDate(this ClassDatePostDto classDatePostDto){
             return new ClassDate{
                Day = classDatePostDto.Day,
                Time = classDatePostDto.Time,
                NumberOfClasses  = classDatePostDto.NumberOfClasses

             };
        }
    }
}