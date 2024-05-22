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
                CourseDetailsId = course.CourseDetailsId
            };
        }

        public static DepartmentCourse ToDepartmentCourse(this DepartmentCoursePostDto course){
            return new DepartmentCourse{
                CourseName = course.CourseName,
                DepartmentName = course.DepartmentName,
                TaughtSemester = course.TaughtSemester,
                CourseDetailsId = course.CourseDetailsId
            };
        }
    }
}