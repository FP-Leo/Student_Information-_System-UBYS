using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Course
    {
        [Key]
        public string? CourseID { get; set; } // Primary Key
        //Navigation Property
        public CourseExplanation? Explanation { get; set; } // One-to-One relationship    
    }
}