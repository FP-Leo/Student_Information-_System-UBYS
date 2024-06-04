
using System.ComponentModel.DataAnnotations;
using api.DTO.SemesterDetails;

namespace api.DTO.CourseSelection
{
    public class Transcript
    {
        [Required]
        public ICollection<SemesterDto>? Semesters { get; set; }
    }
}