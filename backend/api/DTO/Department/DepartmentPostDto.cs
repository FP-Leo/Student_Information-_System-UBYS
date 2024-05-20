using System.ComponentModel.DataAnnotations;

namespace api.DTO.Department
{
    public class DepartmentPostDto
    {
        [Required] 
        public string? DepartmentName { get; set; }
        [Required]
        public string? BuildingNumber { get; set; }
        [Required] 
        public int FloorNumber { get; set; }
        [Required]
        public int FacultyId { get; set; }
        [Required]
        public string? HeadOfDepartmentId { get; set; }
    }
}