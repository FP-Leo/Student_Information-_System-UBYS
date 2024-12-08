using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.AccountInfo.Administrator
{
    public class AdministratorAccountLOGINDto
    {
        [Required]
        public string? Token { get; set; }
        [Required]
        public AdministratorAccountDto? Data { get; set; }
    }
}