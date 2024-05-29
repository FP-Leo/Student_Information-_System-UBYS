
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(DepartmentName),nameof(Semester), IsUnique = true)]
    public class SemesterDetail
    {
        public int Id { get; set;}
        public String? DepartmentName { get; set;}
        public int AcademicYear { get; set;}
        public int Semester { get; set;}
        public int NumberOfObligatoryCourses { get; set;}
        public int NumberOfSelectiveCourses { get; set;}
        public int SelectiveCourseACTS { get; set;}
        public int SelectiveCourseKredi { get; set;}
        public int TotalCourses { get; set;}
        public Department? Department { get; set;}
    }
}