using System.ComponentModel.DataAnnotations;

namespace api.DTO.StudentDepDetails
{
    public class StudentDepDetailsPostDto
    {
        [Required]
        public string? TC { get; set; }
        [Required]
        public string? DepartmentName { get; set; }
        [Required]
        public string? StudentType { get; set; }
        [Required]
        public string? StudentStatus { get; set; }
        [Required]
        [Range(1, 7, ErrorMessage = "Maximum 7 years of study are allowed.")]
        public int CurrentSchoolYear { get; set; }
        [Required]
        [Range(1, 8, ErrorMessage = "There are only 8 semesters per department.")]
        public int CurrentSemester { get; set; }
        [Required]
        [Range(30, 45, ErrorMessage = "Current AKTS must be between 30 and 45.")]
        public int CurrentAKTS { get; set; }
        [Required]
        [Range(0, 240, ErrorMessage = "Total AKTS must be between 0 and 240.")]
        public int TotalAKTS { get; set; }
        [Required]
        [Range(0, 4.0, ErrorMessage = "GNO must be between 0 and 4.")]
        public float Gno { get; set; }
    }
}