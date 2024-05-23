using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;

namespace api.Interfaces
{
    public interface IStudentDepDetailsRepository
    {
        Task<ICollection<StudentDepDetail>> GetStudentDepDetailsByTCAsync(String TC);
        Task<StudentDepDetail?> GetStudentDepDetailAsync(String TC, String depName);
        Task<StudentDepDetail?> CreateStudentDepDetailAsync(StudentDepDetail studentDepDetail);
        Task<StudentDepDetail?> UpdateStudentDepDetailAsync(StudentDepDetail studentDepDetail);
        Task<StudentDepDetail?> DeleteStudentDepDetailAsync(String TC, String depName);
    }
}