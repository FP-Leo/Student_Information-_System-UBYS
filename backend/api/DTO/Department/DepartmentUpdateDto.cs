using System.ComponentModel.DataAnnotations;

namespace api.DTO.Department
{
    public class DepartmentUpdateDto
    {
        [Required]
        public string? DepartmentName { get; set; }
        public string? BuildingNumber { get; set; }
        [Required] 
        public int NumberOfSemesters { get; set; }
        [Required] 
        public int MaxYears {get; set; }
        [Required]
        public DateTime CourseSelectionStartDate { get; set; }
        [Required]
        public DateTime CourseSelectionEndDate { get; set;}
        [Required] 
        public string? DepCode { get; set; }
        public int FloorNumber { get; set; }
        [Required]
        public string? HeadOfDepartmentTC { get; set; }
    }
}