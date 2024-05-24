using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(DepartmentName), nameof(CourseName), nameof(SchoolYear), IsUnique = true)]
    public class CourseClass
    {
        [Key]
        public string? CourseClassID { get; set; } // Primary Key
        public int HourPerWeek { get; set; }
        public int SchoolYear { get; set; }
        public int AKTS { get; set; }
        public int Kredi { get; set; }
        public float MidTermValue { get; set; }
        public float FinalValue { get; set; }
        
        // Foreign Key
        public string? CourseName { get; set; } 
        public string? DepartmentName { get; set; }
        public string? LecturerTC { get; set; }
        // Navigation Property
        public DepartmentCourse? DepartmentCourse{ get; set; }
        public LecturerAccount? LecturerDetails{ get; set; }
        public ICollection<StudentCourseDetails>? StudentsCourseDetails  { get; set; }
    }
}