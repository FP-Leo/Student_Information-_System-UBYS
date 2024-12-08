using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index(nameof(DepartmentName), nameof(TC), IsUnique = true)]
    public class StudentCourseSelection
    {
        public int Id { get; set; }
        public string? DepartmentName { get; set; }
        public string? TC { get; set; }
        public DateTime SentDate { get; set; }
        public string? State { get; set; }
        public StudentDepDetails? StudentDepDetails { get; set; }
        public ICollection<StudentCourseSelect>? SelectedCourses { get; set; }
    }
}