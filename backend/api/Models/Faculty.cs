using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Faculty
    {
        public int FacultyID { get; set; }
        public string? FacultyName { get; set; }
        public string? Address { get; set; }
        public string? Mail { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UniId { get; set; }
        public int DeanId { get; set; }

        // Navigation Properties
        public University? University { get; set; }   //One-to-Many relationship
        public User? Dean { get; set; } // One-to-One relationship 
    }
}