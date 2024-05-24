using api.DTO.CourseDetails;
using api.Models;

namespace api.Mappers
{
    public static class CourseDetailsMapper
    {
        public static CourseDetailsDto ToCourseExplanationDto(this CourseDetails courseExplanation){
            return new CourseDetailsDto{
                Id = courseExplanation.Id,
                CourseName = courseExplanation.CourseName,
                CourseLevel = courseExplanation.CourseLevel,
                CourseType = courseExplanation.CourseType,
                CourseLanguage = courseExplanation.CourseLanguage,
                CourseContent = courseExplanation.CourseContent
            };
        }

        public static CourseDetails ToCourseExplanation(this CourseDetailsPostDto courseExplanation){
            return new CourseDetails{
                CourseName = courseExplanation.CourseName,
                CourseLevel = courseExplanation.CourseLevel,
                CourseType = courseExplanation.CourseType,
                CourseLanguage = courseExplanation.CourseLanguage,
                CourseContent = courseExplanation.CourseContent
            };
        }
    }
}