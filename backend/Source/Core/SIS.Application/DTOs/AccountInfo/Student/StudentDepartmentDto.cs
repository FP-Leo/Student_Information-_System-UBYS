using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.AccountInfo.Student
{
    public class StudentDepartmentDto
    {
        [Required]
        public string? DepartmentName { get; set; }
    }
}