using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class StudentCourseDetails
    {
        [Column(Order = 0)]
        public int Id { get; set;}
        public String? State { get; set;}
        public bool? AttendanceFulfilled { get; set; }
        public DateTime? MidTermAnnouncment { get; set; }
        public int? MidTerm { get; set; }
        public DateTime? FinalAnnouncment { get; set; }
        public int? Final { get; set; }
        public float? Grade { get; set; }
        public bool? ComplementRight { get; set; } // bütünleme hakkı
        public DateTime? ComplementAnnouncment { get; set; }
        public int? Complement { get; set; }
        // Foreign Key
        [Column(Order = 3)]
        public String? TC { get; set; }
        [Column(Order = 2)]
        public String? CourseCode { get; set; }
        [Column(Order = 1)]
        public String? DepartmentName { get; set; }
        public int SchoolYear { get; set; }
        // Navigation Property
        public CourseClass? CourseClass { get; set; }
        public StudentDepDetails? StudentDetails { get; set; }
    }
}