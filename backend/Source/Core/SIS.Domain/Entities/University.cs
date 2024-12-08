using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Address), IsUnique = true)]
    [Index(nameof(WebSite), IsUnique = true)]
    [Index(nameof(Mail), IsUnique = true)]
    [Index(nameof(PhoneNumber), IsUnique = true)]
    public class University
    {
        public University() { }
        public University(string[] data)
        {
            Name = data[0];
            Address = data[1];
            WebSite = data[2];
            Mail = data[3];
            PhoneNumber = data[4];
            CurrentSchoolYear = int.Parse(data[5]);
            RectorTC = data[6];
        }
        [Key]
        public int UniversityId { get; set; }
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
        public string? RectorTC { get; set; }

        // Navigation Properties  
        public ICollection<Faculty>? Faculties { get; set; } // One-to-Many relationship
        public User? Rector { get; set; } // One-to-One
    }
}