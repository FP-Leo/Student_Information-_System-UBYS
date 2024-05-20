using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class CourseExplanation
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CourseLanguage { get; set; }
        public string? CourseLevel { get; set; }
        public string? CourseType { get; set; }
        public string? CourseContent { get; set; }
         // Navigation Property
        public string? CourseID { get; set; } // Foreign Key
        public Course? Course { get; set; } // One-to-Many relationship
    }
}