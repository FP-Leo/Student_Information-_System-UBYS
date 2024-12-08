using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.AccountInfo.Student
{
    public class StudentAccountUpdateDto
    {
        public string? Phone { get; set; }
        public string? PersonalMail { get; set; }
    }
}