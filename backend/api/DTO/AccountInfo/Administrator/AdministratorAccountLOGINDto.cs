using System.ComponentModel.DataAnnotations;
using api.DTO.AccountInfo.Administrator;

namespace api.DTO.AccountInfo
{
    public class AdministratorAccountLOGINDto
    {
        [Required]
        public string? Token {get; set;}
        [Required]
        public AdministratorAccountDataDto? Data {get; set;}
    }
}