using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ICourseClassDateRepository
    {
        Task<CourseClassDate?> GetCourseClassDateByIdAsync(int id);
        Task<CourseClassDate?> CreateCourseClassDateAsync(CourseClassDate courseClassDate);
        Task<CourseClassDate?> UpdateCourseClassDateAsync(CourseClassDate courseClassDate);
        Task<CourseClassDate?> DeleteCourseClassDateByIdAsync(int id);
    }
}