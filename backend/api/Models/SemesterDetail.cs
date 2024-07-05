
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(DepartmentName),nameof(Semester), IsUnique = true)]
    public class SemesterDetail
    {
        public SemesterDetail(){}
        public SemesterDetail(string[] data){
            DepartmentName = data[0];
            AcademicYear = Int32.Parse(data[1]);
            Semester = Int32.Parse(data[2]);
            NumberOfObligatoryCourses = Int32.Parse(data[3]);
            NumberOfSelectiveCourses = Int32.Parse(data[4]);
            SelectiveCourseACTS = Int32.Parse(data[5]);
            SelectiveCourseKredi = Int32.Parse(data[6]);
            TotalCourses = Int32.Parse(data[7]);
        }
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