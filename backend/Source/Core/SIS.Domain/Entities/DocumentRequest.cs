using System.ComponentModel.DataAnnotations.Schema;

namespace SIS.Domain.Entities
{
    public class DocumentRequest
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 2)]
        public string? DocumentType { get; set; }
        public string? DocumentLanguage { get; set; }
        public DateOnly RequestDate { get; set; }
        public string? State { get; set; }
        [Column(Order = 1)]
        public string? TC { get; set; }
        public User? User;
    }
}