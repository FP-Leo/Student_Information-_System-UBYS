using SIS.Application.DTOs.CourseSelection;
using SIS.Domain.Entities;

namespace SIS.Application.MappingProfiles
{
    public static class CourseSelectionMapper
    {
        public static CourseSelectionDto ToCourseSelectionDetailsDto(this StudentCourseSelection courseSelection, ICollection<SelectedCourseGETDto> selectedCourseDtos)
        {
            return new CourseSelectionDto
            {
                TC = courseSelection.TC,
                DepartmentName = courseSelection.DepartmentName,
                SentDate = courseSelection.SentDate,
                State = courseSelection.State,
                SelectedCourses = selectedCourseDtos
            };
        }

        public static List<string> ToCourseCodeList(this ICollection<SelectedCourseGETDto> selectedCourses)
        {
            List<string> courseCodes = [];
            foreach (var course in selectedCourses)
            {
                courseCodes.Add(course.CourseCode);
            }
            return courseCodes;
        }

        public static List<string> GetSpecificCourse(this ICollection<SelectedCourseGETDto> selectedCourses, string CourseType)
        {
            List<string> courseCodes = [];
            foreach (var course in selectedCourses)
            {
                if (course.CourseType == CourseType)
                    courseCodes.Add(course.CourseCode);
            }
            return courseCodes;
        }

        public static int GetSpecificCourseAKTS(this ICollection<SelectedCourseGETDto> selectedCourses, string CourseCode)
        {
            int AKTS = 0;
            foreach (var course in selectedCourses)
            {
                if (course.CourseCode == CourseCode)
                {
                    AKTS = course.AKTS;
                    break;
                }
            }
            return AKTS;
        }
    }
}