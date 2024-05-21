using api.DTO.CourseDetails;
using api.Models;

namespace api.Mappers
{
    public static class CourseExplanationMapper
    {
        public static CourseDetailsDto ToCourseExplanationDto(this CourseDetails courseExplanation){
            return new CourseDetailsDto{
                CourseName = courseExplanation.CourseName,
                DepartmentName = courseExplanation.DepartmentName,
                CourseLevel = courseExplanation.CourseLevel,
                CourseType = courseExplanation.CourseType,
                CourseLanguage = courseExplanation.CourseLanguage,
                CourseContent = courseExplanation.CourseContent
            };
        }

        public static CourseDetails ToCourseExplanation(this CourseDetailsPostDto courseExplanation){
            return new CourseDetails{
                CourseName = courseExplanation.CourseName,
                DepartmentName = courseExplanation.DepartmentName,
                CourseLevel = courseExplanation.CourseLevel,
                CourseType = courseExplanation.CourseType,
                CourseLanguage = courseExplanation.CourseLanguage,
                CourseContent = courseExplanation.CourseContent
            };
        }
    }
}