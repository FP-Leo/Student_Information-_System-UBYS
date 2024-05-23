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
        Task<ICollection<StudentDepDetails>> GetStudentDepDetailsByTCAsync(String TC);
        Task<StudentDepDetails?> GetStudentDepDetailAsync(String TC, String depName);
        Task<ICollection<StudentDepDetails>?> GetDepartmentsStudentsAsync(string DepName);
        Task<StudentDepDetails?> CreateStudentDepDetailAsync(StudentDepDetails studentDepDetail);
        Task<StudentDepDetails?> UpdateStudentDepDetailAsync(StudentDepDetails studentDepDetail);
        Task<StudentDepDetails?> DeleteStudentDepDetailAsync(String TC, String depName);
    }
}