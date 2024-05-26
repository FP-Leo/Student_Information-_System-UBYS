using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.CourseClassDate
{
    public class CourseClassDateUpdateDto
    {
        
        [Required]
        public int Id { get; set; }
        // Foreign Keys
        [Required]
        public string? DepartmentName { get; set; }
        [Required]
        public string? CourseName { get; set; }
        [Required] 
        public int SchoolYear { get; set; }
        [Required]
        public String? Day { get; set; }
        [Required]
        public DateTime? Time { get; set;}
        [Required]
        public int NumberOfClasses { get; set; }
    }
}