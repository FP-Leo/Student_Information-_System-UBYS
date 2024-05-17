using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class University
    {
        public int UniversityId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }

        // Navigation Property    
        public ICollection<Faculty> Faculties { get; set; } // One-to-Many relationship

        // public User Rector { get; set; } // One-to-One or One-to-Many relationship 
    }
}