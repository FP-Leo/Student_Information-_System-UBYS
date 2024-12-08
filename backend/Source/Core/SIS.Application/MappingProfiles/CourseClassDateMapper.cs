using SIS.Application.DTOs.ClassDate;
using SIS.Application.DTOs.CourseClassDate;
using SIS.Application.Interfaces.Repositories;
using SIS.Domain.Entities;

namespace SIS.Application.MappingProfiles
{
    public static class CourseClassDateMapper
    {
        public static CourseClassDate ToCourseClassDate(this CourseClassDatePostDto courseClassDatePostDto, int ClassDateId)
        {
            return new CourseClassDate
            {
                CourseCode = courseClassDatePostDto.CourseCode,
                SchoolYear = courseClassDatePostDto.SchoolYear,
                ClassDateId = ClassDateId
            };
        }
        public static async Task<CourseClassDateDto2> ToCourseClassDatesDto(this ICollection<CourseClassDate> courseClassDates, IClassDateRepository classDateRepository, string name)
        {
            var courseDetails = courseClassDates.FirstOrDefault();
            ICollection<ClassDateDto> ClassDates = [];
            foreach (var cls in courseClassDates)
            {
                var clsDto = await classDateRepository.GetClassDateByIdAsync(cls.ClassDateId);
                if (clsDto != null)
                {
                    ClassDates.Add(clsDto.ToClassDateDto());
                }
            }
            return new CourseClassDateDto2
            {
                CourseName = name,
                ClassDates = ClassDates
            };
        }

        public static ICollection<ClassDate> GetClassDates(this CourseClassDatePostDto courseClassDatePostDto)
        {
            ICollection<ClassDate> ClassDates = [];
            foreach (var cls in courseClassDatePostDto.ClassDates)
            {
                var temp = new ClassDate
                {
                    Day = cls.Day,
                    Time = cls.Time,
                    NumberOfClasses = cls.NumberOfClasses,
                };
                ClassDates.Add(temp);
            }
            return ClassDates;
        }
    }
}