using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.CourseClassDate;
using api.Models;

namespace api.Mappers
{
    public static class CourseClassDateMapper
    {
        public static CourseClassDateDto ToCourseClassDateDto(this CourseClassDate courseClassDate){
            return new CourseClassDateDto{
                Id = courseClassDate.Id,
                DepartmentName = courseClassDate.DepartmentName,
                CourseName = courseClassDate.CourseName,
                SchoolYear = courseClassDate.SchoolYear,
                Day = courseClassDate.Day,
                Time = courseClassDate.Time,
                NumberOfClasses = courseClassDate.NumberOfClasses


            };
        } 
        public static CourseClassDate ToCourseClassDate(this CourseClassDatePostDto courseClassDatePostDto){
             return new CourseClassDate{
                DepartmentName = courseClassDatePostDto.DepartmentName,
                CourseName = courseClassDatePostDto.CourseName,
                SchoolYear = courseClassDatePostDto.SchoolYear,
                Day = courseClassDatePostDto.Day,
                Time = courseClassDatePostDto.Time,
                NumberOfClasses = courseClassDatePostDto.NumberOfClasses
            };
        }
        
    }
}