using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.DeparmentCourse
{
    public class DepartmentCourseUpdateDto
    {   
        [Required]
        public string? DepartmentName { get; set; }    
        [Required]
        public string? CourseName { get; set; } 
        [Required]
        [Range(1, 8, ErrorMessage = "There are only 8 semesters.")]
        public int TaughtSemester { get; set; }
        [Required]
        public int CourseDetailsId { get; set; }
    }
}