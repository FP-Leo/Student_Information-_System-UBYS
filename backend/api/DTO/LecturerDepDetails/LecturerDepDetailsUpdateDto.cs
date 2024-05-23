using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.LecturerDepDetails
{
    public class LecturerDepDetailsUpdateDto
    {
        public string? DepartmentName { get; set; }
        public string? TC { get; set; }
        public int HoursPerWeek { get; set; }
        public DateTime? EndDate { get; set; }
    }
}