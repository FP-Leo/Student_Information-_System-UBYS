using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class StudentDepDetail
    {
        public int DepartmentId { get; set; }
        public string? SSN { get; set; }
        public string? StudentType { get; set; }
        public int CurrentSchoolYear { get; set; }
        public int CurrentSemester { get; set; }
        public int CurrentAKTS { get; set; }
        public int TotalAKTS { get; set; }
        public float Gno { get; set; }
    }
}