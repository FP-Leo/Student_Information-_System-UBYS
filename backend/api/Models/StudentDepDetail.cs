using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Index(nameof(TC), nameof(DepartmentId), IsUnique = true)]
    public class StudentDepDetail
    {
        public int Id { get; set;}
        public string? StudentType { get; set; }
        public string? StudentStatus { get; set; }
        [Range(1, 7, ErrorMessage = "Maximum 7 years of study are allowed.")]
        public int CurrentSchoolYear { get; set; }
        [Range(1, 8, ErrorMessage = "There are only 8 semesters per department.")]
        public int CurrentSemester { get; set; }
        
        [Range(30, 45, ErrorMessage = "Current AKTS must be between 30 and 45.")]
        public int CurrentAKTS { get; set; }
        [Range(0, 240, ErrorMessage = "Total AKTS must be between 0 and 240.")]
        public int TotalAKTS { get; set; }
        [Range(0, 4.0, ErrorMessage = "GNO must be between 0 and 4.")]
        public float Gno { get; set; }
        //Foreign Keys
        public int DepartmentId { get; set; }
        public string? TC { get; set; }
        public Department? Department{ get; set; }
        public StudentAccount? StudentAccount{ get; set; }
    }
}