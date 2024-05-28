using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo
{
    public class LecturerAccountUpdateDto
    {
        public string? Phone {get; set;}
        public string? PersonalMail {get; set;}
    }
}