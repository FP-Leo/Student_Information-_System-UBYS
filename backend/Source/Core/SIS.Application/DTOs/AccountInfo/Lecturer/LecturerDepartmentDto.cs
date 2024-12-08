using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.AccountInfo.Lecturer
{
    public class LecturerDepartmentDto
    {
        [Required]
        public string? DepartmentName { get; set; }
    }
}