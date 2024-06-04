using System.ComponentModel.DataAnnotations;

namespace api.DTO
{
    public class DocumentRequestDto
    {
        [Required]
        public int Id;
        [Required]
        public string? TC;
        [Required]
        public string? DocumentType;
        [Required]
        public string? DocumentLanguage;
        [Required]
        public DateOnly RequestDate;
        [Required]
        public string? State;
    }
}