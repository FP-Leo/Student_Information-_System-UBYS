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
        Task<ICollection<StudentDepDetail>> GetStudentDepDetailsByTC(String TC);
        Task<StudentDepDetail?> GetStudentDepDetailByTcAndDepId(String TC, int depId);
        Task<StudentDepDetail?> CreateStudentDepDetail(StudentDepDetail studentDepDetail);
        Task<StudentDepDetail?> UpdateStudentDepDetail(StudentDepDetail studentDepDetail);
        Task<StudentDepDetail?> DeleteStudentDepDetail(String TC, int depId);
    }
}