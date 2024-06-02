using api.Models;
using api.DTO.CourseSelection;

namespace api.Mappers
{
    public static class CourseSelectionMapper
    {
        public static CourseSelectionDto ToCourseSelectionDetailsDto(this StudentCourseSelection courseSelection, ICollection<SelectedCourseDto> selectedCourseDtos){
            return new CourseSelectionDto{
                TC = courseSelection.TC,
                DepartmentName = courseSelection.DepartmentName,
                SentDate = courseSelection.SentDate,
                State = courseSelection.State,
                SelectedCourses = selectedCourseDtos
            };
        }
    }
}