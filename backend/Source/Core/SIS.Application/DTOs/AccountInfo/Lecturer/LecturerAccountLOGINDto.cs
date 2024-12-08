using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.AccountInfo.Lecturer
{
    public class LecturerAccountLOGINDto
    {
        [Required]
        public string? Token { get; set; }
        [Required]
        public LecturerAccountDto? Data { get; set; }
    }
}