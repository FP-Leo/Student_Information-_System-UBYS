using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class StudentDepDetail
    {
        public int Id { get; set; }
        public string Ssn { get; set; } // Foreign key referencing Student
        public int MajorId { get; set; }
        public int FacultyId { get; set; }
        public int UniId { get; set; }
        public string Type { get; set; }
        public int SchoolYear { get; set; }
        public int Semester { get; set; }
        public string[] CurrentCourseIDs { get; set; }
        public string[] PassedCourseIDs { get; set; }
        public string[] FailedCourseIDs { get; set; }
        public int CurrentAKTS { get; set; }
        public int TotalAKTS { get; set; }
        public float Gno { get; set; }

    }
}