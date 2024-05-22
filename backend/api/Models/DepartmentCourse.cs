using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class DepartmentCourse
    {
        //Primary Key
        public int Id { get; set; }
        public int TaughtSemester { get; set; }
        //Foreign Keys
        public string? CourseName { get; set; } 
        public string? DepartmentName { get; set; }
        public int CourseDetailsId { get; set; }
        //Navigation Property
        public Course? Course{ get; set; }
        public Department? Department { get; set; } 
        public CourseDetails? CourseDetails { get; set; }
    }
}