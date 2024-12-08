using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.Department
{
    public class DepartmentPostDto
    {
        [Required]
        public string? FacultyName { get; set; }
        [Required]
        public string? DepartmentName { get; set; }
        [Required]
        public int NumberOfSemesters { get; set; }
        [Required]
        public int MaxYears { get; set; }
        [Required]
        public DateTime CourseSelectionStartDate { get; set; }
        [Required]
        public DateTime CourseSelectionEndDate { get; set; }
        [Required]
        public string? DepCode { get; set; }
        [Required]
        public string? BuildingNumber { get; set; }
        [Required]
        public int FloorNumber { get; set; }
        [Required]
        public string? HeadOfDepartmentTC { get; set; }
    }
}