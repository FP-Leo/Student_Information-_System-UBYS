using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ICourseDetailsRepository
    {
        Task<CourseDetails?> GetCourseDetailsAsync(String CourseName, String DepartmentName);
        Task<CourseDetails?> AddCourseDetailsAsync(CourseDetails courseExplanation);
        Task<CourseDetails?> UpdateCourseDetailsAsync(CourseDetails courseExplanation);
        Task<CourseDetails?> DeleteCourseDetailsAsync(String CourseName, String DepartmentName);
    }
}