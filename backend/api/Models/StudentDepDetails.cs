using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(TC), nameof(DepartmentName), IsUnique = true)]
    public class StudentDepDetails
    {
        public StudentDepDetails(){}
        public StudentDepDetails(string[] data){
            DepartmentName = data[0];
            RegistrationDate = DateOnly.Parse(data[1]);
            TC = data[2];
            StudentType = data[3];
            StudentStatus = data[4];
            CurrentSchoolYear = Int32.Parse(data[5]);
            CurrentSemester = Int32.Parse(data[6]);
            CurrentAKTS = Int32.Parse(data[7]);
            Gno = Int32.Parse(data[8]);
        }
        [Column(Order = 0)]
        public int Id { get; set;}
        [Required]
        public DateOnly RegistrationDate {get; set;}
        public string? StudentType { get; set; }
        public string? StudentStatus { get; set; }
        [Range(1, 7, ErrorMessage = "Maximum 7 years of study are allowed.")]
        public int CurrentSchoolYear { get; set; }
        [Range(1, 8, ErrorMessage = "There are only 8 semesters.")]
        public int CurrentSemester { get; set; } 
        [Range(30, 45, ErrorMessage = "Current AKTS must be between 30 and 45.")]
        public int CurrentAKTS { get; set; }
        [Range(0, 240, ErrorMessage = "Total AKTS must be between 0 and 240.")]
        public int TotalAKTS { get; set; }
        [Range(0, 4.0, ErrorMessage = "GNO must be between 0 and 4.")]
        public float? Gno { get; set; }
        //Foreign Keys
        [Column(Order = 2)]
        public string? DepartmentName { get; set; }
        [Column(Order = 1)]
        public string? TC { get; set; }
        public Department? Department{ get; set; }
        public StudentAccount? StudentAccount{ get; set; }
        public ICollection<StudentCourseDetails>? StudentCoursesDetails { get; set; }
        public StudentCourseSelection? StudentCourseSelection{ get; set; }
    }
}