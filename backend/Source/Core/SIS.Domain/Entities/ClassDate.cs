
using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index(nameof(Day), nameof(Time), nameof(NumberOfClasses), IsUnique = true)]
    public class ClassDate
    {
        public ClassDate() { }
        public ClassDate(string[] data)
        {
            Day = data[0];
            Time = TimeOnly.Parse(data[1]);
            NumberOfClasses = int.Parse(data[2]);
        }
        public int Id { get; set; }
        public string? Day { get; set; }
        public TimeOnly Time { get; set; }
        public int NumberOfClasses { get; set; } // Ex if two it's Time + 45, 5 min break, then 45 mins more.
        public ICollection<CourseClassDate>? CourseClassDates { get; set; }
    }
}