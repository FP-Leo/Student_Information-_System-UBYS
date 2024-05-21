using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class CourseDetails
    {
        public int Id { get; set; }
        public string? CourseLanguage { get; set; }
        public string? CourseLevel { get; set; }
        public string? CourseType { get; set; }
        public string? CourseContent { get; set; }
        public string? CourseName { get; set; } // Foreign Key
        public string? DepartmentName { get; set; } // Foreign Key
        // Navigation Property
        public ICollection<DepartmentCourse>? DepartmentCourses { get; set; } // One-to-Many relationship
    }
}