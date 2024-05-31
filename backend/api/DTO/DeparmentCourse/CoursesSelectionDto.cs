namespace api.DTO.DeparmentCourse
{
    public class CoursesSelectionDto
    {
        public ICollection<CourseSelectionDto>? CurrentSemesterCourses { get; set; }
        public ICollection<CourseSelectionDto>? FailedCourses { get; set; }
        public ICollection<CourseSelectionDto>? PassedCourses { get; set; }
        public ICollection<CourseSelectionDto>? PartiallyPassedCourses { get; set; } // koşulu
        public ICollection<CourseSelectionDto>? OverHeadCourses { get; set; } // üstten
    }
}