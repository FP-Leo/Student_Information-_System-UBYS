namespace api.Models
{
    public class CourseClassDate
    {
        public int Id { get; set; }
        // Foreign Keys
        public string? DepartmentName { get; set; }
        public string? CourseName { get; set; } 
        public int SchoolYear { get; set; }
        public String? Day { get; set; }
        public DateTime? Time { get; set;}
        public int NumberOfClasses { get; set; }
        // Navigation 
        public CourseClass? CourseClass { get; set; }
        public ClassDate? ClassDate { get; set; }
    }
}