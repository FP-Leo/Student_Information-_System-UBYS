using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIS.Application.DTOs.Course
{
    public class CourseUpdateDto
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public string? CourseName { get; set; }
    }
}