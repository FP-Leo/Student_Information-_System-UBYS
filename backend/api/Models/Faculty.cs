using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(FacultyID), nameof(FacultyName), IsUnique = true)]
    [Index(nameof(Address), IsUnique = true)]
    [Index(nameof(Mail), IsUnique = true)]
    [Index(nameof(WebSite), IsUnique = true)]
    [Index(nameof(PhoneNumber), IsUnique = true)]
    public class Faculty
    {
        [Key]
        public int FacultyID { get; set; }
        [Required]
        public string? FacultyName { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Mail { get; set; }
        [Required]
        public string? WebSite { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        public int? UniId { get; set; }
        public string? DeanTC { get; set; }

        // Navigation Properties
        public University? University { get; set; }   //One-to-Many relationship
        public User? Dean { get; set; } // One-to-One relationship 
        public ICollection<Department>? Departments { get; set; }
    }
}