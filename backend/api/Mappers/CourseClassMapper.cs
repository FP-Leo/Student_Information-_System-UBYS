using api.DTO.CourseClass;
using api.Models;

namespace api.Mappers
{
    public static class CourseClassMapper
    {
        public static CourseClassDto ToCourseClassDto(this CourseClass courseClass, String CourseName){
            return new CourseClassDto{
                CourseClassID = courseClass.CourseClassID,
                CourseCode = courseClass.CourseCode,
                CourseName = CourseName,
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
                CourseCode = courseClass.CourseCode,
                SchoolYear = SchoolYear,
                LecturerTC = courseClass.LecturerTC,
                HourPerWeek = courseClass.HourPerWeek,
                AKTS =  courseClass.AKTS,
                Kredi = courseClass.Kredi,
                MidTermValue = courseClass.MidTermValue,
                FinalValue = courseClass.FinalValue
            };
        }

        public static CourseClass ToCourseClass(this CourseClassPostWOCodeDto courseClass, int SchoolYear, String CourseCode){
            return new CourseClass{
                CourseCode = CourseCode,
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