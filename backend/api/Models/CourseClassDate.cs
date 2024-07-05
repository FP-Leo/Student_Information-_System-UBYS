using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(CourseCode), nameof(SchoolYear), nameof(ClassDateId), IsUnique = true)]
    public class CourseClassDate
    {
        public CourseClassDate(){}
        public CourseClassDate(string[] data){
            CourseCode = data[0];
            SchoolYear = Int32.Parse(data[1]);
            ClassDateId = Int32.Parse(data[2]);
        }
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