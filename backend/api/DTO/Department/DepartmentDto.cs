using System.ComponentModel.DataAnnotations;

namespace api.DTO.Department
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        [Required] 
        public string? FacultyName { get; set; }
        [Required] 
        public string? DepartmentName { get; set; }
        [Required] 
        public int NumberOfSemesters { get; set; }
        [Required] 
        public int MaxYears {get; set; }
        [Required] 
        public string? BuildingNumber { get; set; }
        [Required] 
        public int FloorNumber { get; set; }
        [Required] 
        public string? HeadOfDepartmentTC { get; set; }
    }
}