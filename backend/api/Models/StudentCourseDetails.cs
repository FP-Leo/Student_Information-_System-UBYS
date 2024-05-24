namespace api.Models
{
    public class StudentCourseDetails
    {
        public int Id { get; set;}
        public bool AttendanceFulfilled { get; set; }
        public float MidTerm { get; set; }
        public float Final { get; set; }
        public float Grade { get; set; }
        // Foreign Key
        public String? TC { get; set; }
        public String? CourseName { get; set; }
        public String? DepartmentName { get; set; }
        public int SchoolYear { get; set; }
        // Navigation Property
        public CourseClass? CourseClass { get; set; }
        public StudentAccount? StudentAccount{ get; set; }
    }
}