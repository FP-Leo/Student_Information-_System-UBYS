using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index(nameof(DepartmentName), nameof(Semester), IsUnique = true)]
    public class SemesterDetail
    {
        public SemesterDetail() { }
        public SemesterDetail(string[] data)
        {
            DepartmentName = data[0];
            AcademicYear = int.Parse(data[1]);
            Semester = int.Parse(data[2]);
            NumberOfObligatoryCourses = int.Parse(data[3]);
            NumberOfSelectiveCourses = int.Parse(data[4]);
            SelectiveCourseACTS = int.Parse(data[5]);
            SelectiveCourseKredi = int.Parse(data[6]);
            TotalCourses = int.Parse(data[7]);
        }
        public int Id { get; set; }
        public string? DepartmentName { get; set; }
        public int AcademicYear { get; set; }
        public int Semester { get; set; }
        public int NumberOfObligatoryCourses { get; set; }
        public int NumberOfSelectiveCourses { get; set; }
        public int SelectiveCourseACTS { get; set; }
        public int SelectiveCourseKredi { get; set; }
        public int TotalCourses { get; set; }
        public Department? Department { get; set; }
    }
}