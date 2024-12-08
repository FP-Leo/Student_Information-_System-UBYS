using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index(nameof(CourseCode), nameof(SchoolYear), IsUnique = true)]
    public class CourseClass
    {
        public CourseClass() { }
        public CourseClass(string[] data)
        {
            CourseCode = data[0];
            SchoolYear = int.Parse(data[1]);
            LecturerTC = data[2];
            HourPerWeek = int.Parse(data[3]);
            AKTS = int.Parse(data[4]);
            Kredi = int.Parse(data[5]);
            MidTermValue = int.Parse(data[6]);
            FinalValue = int.Parse(data[7]);
        }
        [Key]
        public int CourseClassID { get; set; } // Primary Key
        public int HourPerWeek { get; set; }
        public int SchoolYear { get; set; }
        public int AKTS { get; set; }
        public int Kredi { get; set; }
        public int MidTermValue { get; set; }
        public int FinalValue { get; set; }

        // Foreign Key
        public string? CourseCode { get; set; }
        public string? LecturerTC { get; set; }
        // Navigation Property
        public DepartmentCourse? DepartmentCourse { get; set; }
        public LecturerAccount? LecturerDetails { get; set; }
        public ICollection<StudentCourseDetails>? StudentsCourseDetails { get; set; }
        public ICollection<CourseClassDate>? CourseClassDates { get; set; }
    }
}