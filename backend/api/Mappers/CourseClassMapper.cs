using api.DTO.CourseClass;
using api.Models;

namespace api.Mappers
{
    public static class CourseClassMapper
    {
        public static CourseClassDto ToCourseClassDto(this CourseClass courseClass){
            return new CourseClassDto{
                CourseClassID = courseClass.CourseClassID,
                DepartmentName = courseClass.DepartmentName,
                CourseName = courseClass.CourseName,
                SchoolYear = courseClass.SchoolYear,
                LecturerTC = courseClass.LecturerTC,
                HourPerWeek = courseClass.HourPerWeek,
                AKTS =  courseClass.AKTS,
                Kredi = courseClass.Kredi,
                MidTermValue = courseClass.MidTermValue,
                FinalValue = courseClass.FinalValue
            };
        }
        public static CourseClass ToCourseClass(this CourseClassPostDto courseClass, int SchoolYear){
            return new CourseClass{
                DepartmentName = courseClass.DepartmentName,
                CourseName = courseClass.CourseName,
                SchoolYear = SchoolYear,
                LecturerTC = courseClass.LecturerTC,
                HourPerWeek = courseClass.HourPerWeek,
                AKTS =  courseClass.AKTS,
                Kredi = courseClass.Kredi,
                MidTermValue = courseClass.MidTermValue,
                FinalValue = courseClass.FinalValue
            };
        }
    }
}