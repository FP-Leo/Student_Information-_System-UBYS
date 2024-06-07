using api.Models;
using api.DTO.CourseSelection;

namespace api.Mappers
{
    public static class CourseSelectionMapper
    {
        public static CourseSelectionDto ToCourseSelectionDetailsDto(this StudentCourseSelection courseSelection, ICollection<SelectedCourseGETDto> selectedCourseDtos){
            return new CourseSelectionDto{
                TC = courseSelection.TC,
                DepartmentName = courseSelection.DepartmentName,
                SentDate = courseSelection.SentDate,
                State = courseSelection.State,
                SelectedCourses = selectedCourseDtos
            };
        }

        public static List<String> ToCourseCodeList(this ICollection<SelectedCourseGETDto> selectedCourses){
            List<String> courseCodes = [];
            foreach (var course in selectedCourses){
                courseCodes.Add(course.CourseCode);
            }
            return courseCodes;
        }

        public static List<String> GetSpecificCourse(this ICollection<SelectedCourseGETDto> selectedCourses, String CourseType){
            List<String> courseCodes = [];
            foreach (var course in selectedCourses){
                if(course.CourseType == CourseType)
                    courseCodes.Add(course.CourseCode);
            }
            return courseCodes;
        }

        public static int GetSpecificCourseAKTS(this ICollection<SelectedCourseGETDto> selectedCourses, String CourseCode){
            int AKTS = 0;
            foreach (var course in selectedCourses){
                if(course.CourseCode == CourseCode){
                    AKTS = course.AKTS;
                    break;
                }
            }
            return AKTS;
        }
    }
}