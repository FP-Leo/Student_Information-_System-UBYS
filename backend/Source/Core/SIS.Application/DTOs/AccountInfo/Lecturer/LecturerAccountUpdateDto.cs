using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.AccountInfo.Lecturer
{
    public class LecturerAccountUpdateDto
    {
        public string? Phone { get; set; }
        public string? PersonalMail { get; set; }
    }
}