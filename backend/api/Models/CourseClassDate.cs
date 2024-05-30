using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(CourseCode), nameof(SchoolYear), nameof(ClassDateId), IsUnique = true)]
    public class CourseClassDate
    {
        public int Id { get; set; }
        // Foreign Keys
        public string? CourseCode { get; set; }
        public int SchoolYear { get; set; }
        public int ClassDateId { get; set; }
        // Navigation 
        public CourseClass? CourseClass { get; set; }
        public ClassDate? ClassDate { get; set; }
    }
}