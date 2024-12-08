using SIS.Application.DTOs.DeparmentCourse;
using SIS.Domain.Entities;

namespace SIS.Application.MappingProfiles
{
    public static class DepartmentCourseMapper
    {
        public static DepartmentCourseDto ToDepartmentCourseDto(this DepartmentCourse course)
        {
            return new DepartmentCourseDto
            {
                CourseName = course.CourseName,
                DepartmentName = course.DepartmentName,
                TaughtSemester = course.TaughtSemester,
                CourseCode = course.CourseCode,
                Status = course.Status,
                CourseDetailsId = course.CourseDetailsId
            };
        }

        public static DepartmentCourse ToDepartmentCourse(this DepartmentCoursePostDto course, string CourseCode)
        {
            return new DepartmentCourse
            {
                CourseName = course.CourseName,
                DepartmentName = course.DepartmentName,
                TaughtSemester = course.TaughtSemester,
                CourseCode = CourseCode,
                Status = "Closed",
                CourseDetailsId = course.CourseDetailsId
            };
        }

        public static ICollection<DepartmentCourseDto> ToDepartmentCourseDto(this ICollection<DepartmentCourse> courses)
        {
            ICollection<DepartmentCourseDto> coursesDto = [];
            foreach (DepartmentCourse course in courses)
            {
                coursesDto.Add(course.ToDepartmentCourseDto());
            }
            return coursesDto;
        }
    }
}