using System.ComponentModel.DataAnnotations;

namespace api.DTO.Department
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        [Required] 
        public string? DepartmentName { get; set; }
        [Required] 
        public string? BuildingNumber { get; set; }
        [Required] 
        public int FloorNumber { get; set; }
        public int FacultyId { get; set; }
        public string? HeadOfDepartmentTC { get; set; }
    }
}