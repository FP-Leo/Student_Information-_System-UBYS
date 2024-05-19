using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo
{
    public class AdvisorAccountDto
    {
        [Required]
        public string? FirstName {get; set;}
        [Required]
        public string? LastName {get; set;}
        [Required]
        public DateTime BirthDate {get; set;}
        [Required]
        public int AdvisorId {get; set;}
        [Required]
        public DateTime RegisterDate {get; set;}
        [Required]
        public string? SchoolMail {get; set;}
        [Required]
        public string? PersonalMail {get; set;}
        public string? Phone {get; set;}
    }
}