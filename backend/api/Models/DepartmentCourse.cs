using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(DepartmentName), nameof(CourseName), nameof(TaughtSemester),IsUnique = true)]
    [Index(nameof(CourseCode), IsUnique = true)]
    public class DepartmentCourse
    {
        [Required]
        [Column(Order = 0)]
        //Primary Key
        public int Id { get; set; }
        public int TaughtSemester { get; set; }
        public String? CourseCode { get; set; }
        public String? Status { get; set; }
        //Foreign Keys
        [Required]
        [Column(Order = 2)]
        public String? CourseName { get; set; } 
        [Required]
        [Column(Order = 1)]
        public String? DepartmentName { get; set; }
        public int CourseDetailsId { get; set; }
        //Navigation Property
        public Course? Course{ get; set; }
        public Department? Department { get; set; } 
        public CourseDetails? CourseDetails { get; set; }
        public IEnumerable<CourseClass>? CourseClasses { get; set; }
    }
}