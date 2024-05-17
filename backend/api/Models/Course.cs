using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Course
    {
        public string CourseID { get; set; } // Primary Key
        //Navigation Property
        public CourseExplanation Explanation { get; set; } // One-to-One relationship    
    }
}