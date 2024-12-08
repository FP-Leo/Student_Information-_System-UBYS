using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIS.Application.DTOs.Course;
using SIS.Domain.Entities;

namespace SIS.Application.MappingProfiles
{
    public static class CourseMapper
    {
        public static CourseDto ToCourseDto(this Course course)
        {
            return new CourseDto
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName
            };
        }
        public static Course ToCourse(this CoursePostDto coursePost)
        {
            return new Course
            {
                CourseName = coursePost.CourseName
            };
        }
    }
}