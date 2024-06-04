using System.ComponentModel.DataAnnotations;

namespace api.DTO.StudentDepDetails
{
    public class StudentDocumentDto
    {
        [Required]
        public string? TC { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateOnly Birthday { get; set; }
        [Required]
        public DateOnly RegistrationDate { get; set; }
        [Required]
        public string? EducationType { get; set; }
        [Required]
        public int TimeOfEducation { get; set; }
        [Required]
        public string? StudentStatus { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string? Program { get; set; }
    }
}