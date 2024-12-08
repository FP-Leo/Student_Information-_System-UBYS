using System.ComponentModel.DataAnnotations;

namespace SIS.Application.DTOs.LecturerDepDetails
{
    public class LectureSchoolDetailsDto
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public ICollection<LecturerFacultyDetailsDto>? Faculties { get; set; }
        [Required]
        public string? CurrentState { get; set; }
    }
}