using api.DTO.ClassDate;
using api.DTO.CourseClassDate;
using api.Interfaces;
using api.Models;

namespace api.Mappers
{
    public static class CourseClassDateMapper
    {
        public static CourseClassDate ToCourseClassDate(this CourseClassDateDeleteDto courseClassDeletePostDto, int ClassDateId){
             return new CourseClassDate{
                DepartmentName = courseClassDeletePostDto.DepartmentName,
                CourseName = courseClassDeletePostDto.CourseName,
                SchoolYear = courseClassDeletePostDto.SchoolYear,
                ClassDateId = ClassDateId
            };
        }
        public static CourseClassDate ToCourseClassDate(this CourseClassDatePostDto courseClassDatePostDto, int ClassDateId){
             return new CourseClassDate{
                DepartmentName = courseClassDatePostDto.DepartmentName,
                CourseName = courseClassDatePostDto.CourseName,
                SchoolYear = courseClassDatePostDto.SchoolYear,
                ClassDateId = ClassDateId
            };
        }
        public static async Task<CourseClassDateDto> ToCourseClassDatesDto(this ICollection<CourseClassDate> courseClassDates, IClassDateRepository classDateRepository){
            var courseDetails = courseClassDates.FirstOrDefault();
            ICollection<ClassDateDto> ClassDates = [];
            foreach(var cls in courseClassDates){
                var clsDto = await classDateRepository.GetClassDateByIdAsync(cls.ClassDateId);
                if(clsDto != null){
                    ClassDates.Add(clsDto.ToClassDateDto());
                }
            }

            return new CourseClassDateDto{
                DepartmentName = courseDetails.DepartmentName,
                CourseName = courseDetails.CourseName,
                SchoolYear = courseDetails.SchoolYear,
                ClassDates = ClassDates
            };
        }

        public static ICollection<ClassDate> GetClassDates(this CourseClassDatePostDto courseClassDatePostDto){
            ICollection<ClassDate> ClassDates = [];
            foreach(var cls in courseClassDatePostDto.ClassDates){
                var temp = new ClassDate{
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