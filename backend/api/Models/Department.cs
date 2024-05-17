using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Department
    {
        public int DepartmentId { get; set; } 
        public string BuildingNumber { get; set; }
        // Navigation Property
        public int UniId { get; set; }
        public int FacultyId { get; set; }
        public University University { get; set; } 
        public Faculty Faculty { get; set; } 
       // public User HeadOfDepartment { get; set; } // One-to-One 

    }
}