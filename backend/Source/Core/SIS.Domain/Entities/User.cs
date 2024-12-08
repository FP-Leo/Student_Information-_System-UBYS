
using Microsoft.AspNetCore.Identity;

namespace SIS.Domain.Entities
{
    public class User : IdentityUser
    {
        public UserAccount? UserAccount { get; set; }
        public University? University { get; set; }
        public Faculty? Faculty { get; set; }
        public Department? Department { get; set; }
        public ICollection<DocumentRequest>? RequestedDocuments { get; set; }
    }
}