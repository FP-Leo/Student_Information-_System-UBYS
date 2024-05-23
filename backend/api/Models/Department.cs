using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(DepartmentName), IsUnique = true)]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string? DepartmentName { get; set; }
        [Required] 
        public string? BuildingNumber { get; set; }
        [Required] 
        public int FloorNumber { get; set; }
        public string? FacultyName { get; set; }
        public string? HeadOfDepartmentTC { get; set; }

        // Navigation Properties
        public Faculty? Faculty { get; set; } 
        public User? HeadOfDepartment { get; set; } // One-to-One 
        public ICollection<StudentDepDetail>? StudentDepDetails { get; set;}
        public ICollection<LecturerDepDetail>? LecturerDepDetails { get; set;}
        public DepartmentCourse? DepartmentCourse { get; set; } // Many to Many. New table.
    }
}