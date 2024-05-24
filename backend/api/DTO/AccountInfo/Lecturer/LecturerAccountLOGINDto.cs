using System.ComponentModel.DataAnnotations;
using api.DTO.AccountInfo.Lecturer;

namespace api.DTO.AccountInfo
{
    public class LecturerAccountLOGINDto
    {
        [Required]
        public string? Token { get; set; }
        [Required]
        public LecturerAccountDataDto? Data { get; set; }
    }
}