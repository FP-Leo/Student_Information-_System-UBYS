using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo.Student
{
    public class StudentDepartmentDto
    {
        [Required]
        public String? DepartmentName { get; set; }
    }
}