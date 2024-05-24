using System.ComponentModel.DataAnnotations;
using api.DTO.AccountInfo.Advisor;

namespace api.DTO.AccountInfo
{
    public class AdvisorAccountLOGINDto
    {
        [Required]
        public string? Token { get; set; }
        [Required]
        public AdvisorAccountDataDto? Data { get; set; }
    }
}