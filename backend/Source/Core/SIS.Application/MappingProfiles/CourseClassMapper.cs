using SIS.Application.DTOs.CourseClass;
using SIS.Domain.Entities;

namespace SIS.Application.MappingProfiles
{
    public static class CourseClassMapper
    {
        public static CourseClassDto ToCourseClassDto(this CourseClass courseClass, string CourseName)
        {
            return new CourseClassDto
            {
                CourseClassID = courseClass.CourseClassID,
                CourseCode = courseClass.CourseCode,
                CourseName = CourseName,
                SchoolYear = courseClass.SchoolYear,
                LecturerTC = courseClass.LecturerTC,
                HourPerWeek = courseClass.HourPerWeek,
                AKTS = courseClass.AKTS,
                Kredi = courseClass.Kredi,
                MidTermValue = courseClass.MidTermValue,
                FinalValue = courseClass.FinalValue
            };
        }
        public static CourseClass ToCourseClass(this CourseClassPostDto courseClass, int SchoolYear)
        {
            return new CourseClass
            {
                CourseCode = courseClass.CourseCode,
                SchoolYear = SchoolYear,
                LecturerTC = courseClass.LecturerTC,
                HourPerWeek = courseClass.HourPerWeek,
                AKTS = courseClass.AKTS,
                Kredi = courseClass.Kredi,
                MidTermValue = courseClass.MidTermValue,
                FinalValue = courseClass.FinalValue
            };
        }

        public static CourseClass ToCourseClass(this CourseClassPostWOCodeDto courseClass, int SchoolYear, string CourseCode)
        {
            return new CourseClass
            {
                CourseCode = CourseCode,
                SchoolYear = SchoolYear,
                LecturerTC = courseClass.LecturerTC,
                HourPerWeek = courseClass.HourPerWeek,
                AKTS = courseClass.AKTS,
                Kredi = courseClass.Kredi,
                MidTermValue = courseClass.MidTermValue,
                FinalValue = courseClass.FinalValue
            };
        }
    }
}