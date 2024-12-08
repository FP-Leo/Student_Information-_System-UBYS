namespace SIS.Application.DTOs.CourseSelection
{
    public class CoursesSelectionGETDto
    {
        public ICollection<SelectedCourseGETDto>? CurrentSemesterCourses { get; set; }
        public ICollection<SelectedCourseGETDto>? FailedCourses { get; set; }
        public ICollection<SelectedCourseGETDto>? PassedCourses { get; set; }
        public ICollection<SelectedCourseGETDto>? PartiallyPassedCourses { get; set; } // koşulu
        public ICollection<SelectedCourseGETDto>? OverHeadCourses { get; set; } // üstten
    }
}