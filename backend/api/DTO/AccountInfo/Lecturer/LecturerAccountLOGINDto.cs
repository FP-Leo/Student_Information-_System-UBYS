using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo
{
    public class LecturerAccountLOGINDto
    {
        [Required]
        public string? Role {get; set;}
        [Required]
        public string? FirstName {get; set;}
        [Required]
        public string? LastName {get; set;}
        [Required]
        public DateTime BirthDate {get; set;}
        [Required]
        public int LecturerId {get; set;}
        [Required]
        public DateTime RegisterDate {get; set;}
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? CurrentStatus { get; set; }
        [Required]
        public float TotalWorkHours {get; set;}
        [Required]
        public string? SchoolMail {get; set;}
        public string? PersonalMail {get; set;}
        [Required]
        public string? Phone {get; set;}
    }
}