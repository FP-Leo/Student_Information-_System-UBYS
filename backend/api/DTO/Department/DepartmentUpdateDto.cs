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
        public int FloorNumber { get; set; }
        [Required]
        public string? HeadOfDepartmentTC { get; set; }
    }
}