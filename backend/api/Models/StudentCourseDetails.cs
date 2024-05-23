namespace api.Models
{
    public class StudentCourseDetails
    {
        public string? ClassID { get; set; }
        public string? SSN { get; set; } 
        public bool AttendanceFulfilled { get; set; }
        public float MidTerm { get; set; }
        public float Final { get; set; }
        public float Grade { get; set; }
    }
}