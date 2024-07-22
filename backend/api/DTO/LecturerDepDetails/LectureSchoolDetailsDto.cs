using System.ComponentModel.DataAnnotations;

namespace api.DTO.LecturerDepDetails
{
    public class LectureSchoolDetailsDto
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public String? Name { get; set; }
        [Required]
        public ICollection<LecturerFacultyDetailsDto>? Faculties { get; set; }
        [Required]
        public String? CurrentState { get; set; }
    }
}