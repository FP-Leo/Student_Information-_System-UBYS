using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.Course;
using api.Models;

namespace api.Mappers
{
    public static class CourseMapper
    {
        public static CourseDto ToCourseDto(this Course course){
            return new CourseDto{
                CourseId = course.CourseId,
                CourseName = course.CourseName
            };
        }
        public static Course ToCourse(this CoursePostDto coursePost){
            return new Course{
                CourseName = coursePost.CourseName
            };
        }
    }
}