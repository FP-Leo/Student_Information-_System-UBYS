using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo
{
    public class AdministratorAccountLOGINDto
    {
        [Required]
        public string? Token {get; set;}
        [Required]
        public AdministratorAccountDto? Data {get; set;}
    }
}