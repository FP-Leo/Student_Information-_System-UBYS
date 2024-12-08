using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace SIS.Domain.Entities
{
    [Index(nameof(FacultyName), IsUnique = true)]
    [Index(nameof(UniName), nameof(FacultyName), IsUnique = true)]
    [Index(nameof(Address), IsUnique = true)]
    [Index(nameof(Mail), IsUnique = true)]
    [Index(nameof(WebSite), IsUnique = true)]
    [Index(nameof(PhoneNumber), IsUnique = true)]
    public class Faculty
    {
        public Faculty() { }
        public Faculty(string[] data)
        {
            UniName = data[0];
            FacultyName = data[1];
            Address = data[2];
            WebSite = data[3];
            Mail = data[4];
            PhoneNumber = data[5];
            DeanTC = data[6];
        }
        [Key]
        [Column(Order = 0)]
        public int FacultyID { get; set; }
        [Required]
        [Column(Order = 2)]
        public string? FacultyName { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Mail { get; set; }
        [Required]
        public string? WebSite { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Column(Order = 1)]
        public string? UniName { get; set; }
        public string? DeanTC { get; set; }

        // Navigation Properties
        public University? University { get; set; }   //One-to-Many relationship
        public User? Dean { get; set; } // One-to-One relationship 
        public ICollection<Department>? Departments { get; set; }
    }
}