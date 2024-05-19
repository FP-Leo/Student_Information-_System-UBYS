using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Department
    {
        public int DepartmentId { get; set; } 
        public string? BuildingNumber { get; set; }
        public int FacultyId { get; set; }

        // Navigation Properties
        public Faculty? Faculty { get; set; } 
        public User? HeadOfDepartment { get; set; } // One-to-One 
    }
}