using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace SIS.Domain.Entities
{
    [Index(nameof(DepartmentName), nameof(CourseName), nameof(TaughtSemester), IsUnique = true)]
    [Index(nameof(CourseCode), IsUnique = true)]
    public class DepartmentCourse
    {
        public DepartmentCourse() { }
        public DepartmentCourse(string[] data)
        {
            DepartmentName = data[0];
            CourseName = data[1];
            TaughtSemester = int.Parse(data[2]);
            Status = data[3];
            CourseDetailsId = int.Parse(data[4]);
            CourseCode = data[5];
        }
        [Required]
        [Column(Order = 0)]
        //Primary Key
        public int Id { get; set; }
        public int TaughtSemester { get; set; }
        public string? CourseCode { get; set; }
        public string? Status { get; set; }
        //Foreign Keys
        [Required]
        [Column(Order = 2)]
        public string? CourseName { get; set; }
        [Required]
        [Column(Order = 1)]
        public string? DepartmentName { get; set; }
        public int CourseDetailsId { get; set; }
        //Navigation Property
        public Course? Course { get; set; }
        public Department? Department { get; set; }
        public CourseDetails? CourseDetails { get; set; }
        public IEnumerable<CourseClass>? CourseClasses { get; set; }
    }
}