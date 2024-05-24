using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo
{
    public class LecturerAccountLOGINDto
    {
        [Required]
        public string? Token { get; set; }
        [Required]
        public LecturerAccountDto? Data { get; set; }
    }
}