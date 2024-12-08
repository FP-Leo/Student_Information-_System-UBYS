using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.AccountInfo.Administrator
{
    public class AdministratorAccountUpdateDto
    {
        public string? Phone { get; set; }
        public string? PersonalMail { get; set; }
    }
}