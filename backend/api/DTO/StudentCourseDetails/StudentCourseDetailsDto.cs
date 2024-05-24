using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.StudentCourseDetails
{
    public class StudentCourseDetailsDto
    {
        [Required]
        public int Id { get; set;}
        [Required]
        public String? DepartmentName { get; set; }
        [Required]
        public String? CourseName { get; set; }
        [Required]
        public int SchoolYear { get; set; }
        [Required]
        public String? TC { get; set; }
        [Required]
        public String? State { get; set;}
        [Required]
        public bool AttendanceFulfilled { get; set; }
        [Required]
        public float? MidTerm { get; set; }
        [Required]
        public float? Final { get; set; }
        [Required]
        public float? Grade { get; set; }
    }
}