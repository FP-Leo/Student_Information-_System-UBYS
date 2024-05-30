using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{    
    [Index(nameof(CourseName), IsUnique = true)]
    public class Course
    {
        [Key]
        public int CourseId { get; set; } 
        public string? CourseName { get; set; }
        public ICollection<DepartmentCourse>? DepartmentCourses{ get; set; } // M to N relationship. New table.
    }
}