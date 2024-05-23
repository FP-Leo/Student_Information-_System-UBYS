using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
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
    }
}