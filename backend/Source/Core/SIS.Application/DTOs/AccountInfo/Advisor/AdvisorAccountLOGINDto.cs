using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.AccountInfo.Advisor
{
    public class AdvisorAccountLOGINDto
    {
        [Required]
        public string? Token { get; set; }
        [Required]
        public AdvisorAccountDto? Data { get; set; }
    }
}