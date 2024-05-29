using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo
{
    public class AdvisorAccountLOGINDto
    {
        [Required]
        public string? Token { get; set; }
        [Required]
        public AdvisorAccountDto? Data { get; set; }
    }
}