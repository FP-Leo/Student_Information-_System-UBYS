using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IUniversityRepository
    {
        Task<University?> GetUniversityByIdAsync(int id);
        Task<University?> CreateUniversityAsync(University university);
        Task<University?> UpdateUniversityAsync(University university);
        Task<University?> DeleteUniversityByIdAsync(int id);
    }
}