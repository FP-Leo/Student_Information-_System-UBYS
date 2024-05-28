using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(DepartmentName), IsUnique = true)]
    public class Department
    {
        [Key]
        [Column(Order = 0)]
        public int DepartmentId { get; set; }
        [Required]
        [Column(Order = 2)]
        public string? DepartmentName { get; set; }
        [Required] 
        public string? BuildingNumber { get; set; }
        [Required] 
        public int FloorNumber { get; set; }
        [Column(Order = 1)]
        public string? FacultyName { get; set; }
        public string? HeadOfDepartmentTC { get; set; }
        public int NumberOfSemesters { get; set; }
        public int MaxYears {get; set; }

        // Navigation Properties
        public Faculty? Faculty { get; set; } 
        public User? HeadOfDepartment { get; set; } // One-to-One 
        public ICollection<StudentDepDetails>? StudentDepDetails { get; set;}
        public ICollection<LecturerDepDetails>? LecturerDepDetails { get; set;}
        public ICollection<DepartmentCourse>? DepartmentCourses { get; set; } // Many to Many. New table.
        public ICollection<SemesterDetail>? SemestersDetails{ get; set; }
    }
}