using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(DepartmentName), IsUnique = true)]
    [Index(nameof(DepCode), IsUnique = true)]
    public class Department
    {
        public Department(){}
        public Department(string[] data){
            FacultyName = data[0];
            DepartmentName = data[1];
            NumberOfSemesters = Int32.Parse(data[2]);
            MaxYears = Int32.Parse(data[3]);
            CourseSelectionStartDate = DateTime.Parse(data[4]);
            CourseSelectionEndDate = DateTime.Parse(data[5]);
            DepCode = data[6];
            BuildingNumber = data[7];
            FloorNumber = Int32.Parse(data[8]);
            HeadOfDepartmentTC = data[9];
        }
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
        public DateTime CourseSelectionStartDate { get; set; }
        public DateTime CourseSelectionEndDate { get; set;}
        public string? DepCode { get; set; }

        // Navigation Properties
        public Faculty? Faculty { get; set; } 
        public User? HeadOfDepartment { get; set; } // One-to-One 
        public ICollection<StudentDepDetails>? StudentDepDetails { get; set;}
        public ICollection<LecturerDepDetails>? LecturerDepDetails { get; set;}
        public ICollection<DepartmentCourse>? DepartmentCourses { get; set; } // Many to Many. New table.
        public ICollection<SemesterDetail>? SemestersDetails{ get; set; }
    }
}