using System.ComponentModel.DataAnnotations;

namespace api.DTO.StudentDepDetails
{
    public class DepDetailDto
    {
        [Required]
        public String? DepartmentName { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public float? GNO { get; set; }
        [Required]
        public String? State{ get; set; }
    }
}