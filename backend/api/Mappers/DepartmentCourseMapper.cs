using api.DTO.DepartmentCourse;
using api.Models;

namespace api.Mappers
{
    public static class DepartmentCourseMapper
    {
        public static DepartmentCourseDto ToDepartmentCourseDto(this DepartmentCourse course){
            return new DepartmentCourseDto{
                CourseName = course.CourseName,
                DepartmentName = course.DepartmentName,
                TaughtSemester = course.TaughtSemester,
                Status = course.Status,
                CourseDetailsId = course.CourseDetailsId
            };
        }

        public static DepartmentCourse ToDepartmentCourse(this DepartmentCoursePostDto course){
            return new DepartmentCourse{
                CourseName = course.CourseName,
                DepartmentName = course.DepartmentName,
                TaughtSemester = course.TaughtSemester,
                Status = "Closed",
                CourseDetailsId = course.CourseDetailsId
            };
        }

        public static ICollection<DepartmentCourseDto> ToDepartmentCourseDto(this ICollection<DepartmentCourse> courses){
            ICollection<DepartmentCourseDto> coursesDto = [];
            foreach(DepartmentCourse course in courses){
                coursesDto.Add(course.ToDepartmentCourseDto());
            }
            return coursesDto;
        }
    }
}