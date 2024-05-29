using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(TC), nameof(DepartmentName), IsUnique = true)]
    public class LecturerDepDetails
    {
        // Primary key
        public int Id { get; set; } 
        //Foreign Keys
        public string? DepartmentName { get; set; }
        public string? TC { get; set; }
        public int HoursPerWeek { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        // Navigation Properties
        public LecturerAccount? Lecturer { get; set; }
        public Department? Department { get; set; }
    }
}