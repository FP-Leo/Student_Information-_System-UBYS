using System.ComponentModel.DataAnnotations;

namespace api.DTO.Department
{
    public class DepartmentUpdateDto
    {
        [Required]
        public string? DepartmentName { get; set; }
        public string? BuildingNumber { get; set; }
        public int FloorNumber { get; set; }
        [Required]
        public string? HeadOfDepartmentTC { get; set; }
    }
}