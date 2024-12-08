using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index(nameof(TC), nameof(DepartmentName), IsUnique = true)]
    public class LecturerDepDetails
    {
        public LecturerDepDetails() { }
        public LecturerDepDetails(string[] data)
        {
            DepartmentName = data[0];
            TC = data[1];
            HoursPerWeek = int.Parse(data[2]);
            StartDate = DateTime.Parse(data[3]);
            if (data[4] != "null")
                EndDate = DateTime.Parse(data[4]);
            else
                EndDate = null;
        }
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