using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.University
{
    public class UniversityUpdateDto
    {
        [Required]
        public int UniversityId { get; set;}
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? WebSite { get; set; }
        [Required]
        public string? Mail { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public int CurrentSchoolYear { get; set; }
        [Required]
        public string? RectorId { get; set; }
    }
}