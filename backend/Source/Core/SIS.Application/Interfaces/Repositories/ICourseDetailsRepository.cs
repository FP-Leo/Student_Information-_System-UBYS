using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface ICourseDetailsRepository
    {
        Task<CourseDetails?> GetCourseDetailsAsync(int CourseDetailsId);
        Task<CourseDetails?> AddCourseDetailsAsync(CourseDetails courseExplanation);
        Task<CourseDetails?> UpdateCourseDetailsAsync(CourseDetails courseExplanation);
        Task<CourseDetails?> DeleteCourseDetailsAsync(int CourseDetailsId);
    }
}