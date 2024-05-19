using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class University
    {
        [Key]
        public int UniversityId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Mail { get; set; }
        public string? PhoneNumber { get; set; }
        public int CurrentSchoolYear { get; set; }
        public int RectorId { get; set; }
        // Navigation Properties  
        public ICollection<Faculty>? Faculties { get; set; } // One-to-Many relationship
        public User? Rector { get; set; } // One-to-One
    }
}