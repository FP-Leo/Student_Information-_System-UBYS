using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.AccountInfo.Advisor
{
    public class AdvisorAccountUpdateDto
    {
        public string? Phone { get; set; }
        public string? PersonalMail { get; set; }
    }
}