using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo.Lecturer
{
    public class LecturerDepartmentDto
    {
        [Required]
        public String? DepartmentName { get; set; }
    }
}