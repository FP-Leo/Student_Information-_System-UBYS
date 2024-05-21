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
        public int AKTS { get; set; }
        public int Kredi { get; set; }
        public float MidTermValue { get; set; }
        public float FinalValue { get; set; }

        // Navigation Property
        //public string? CourseName { get; set; } // Foreign Key
        //public Course? Course { get; set; } // One-to-Many relationship
         //public string CoursePersonel { get; set; }
    }
}