using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIS.Domain.Entities;

namespace SIS.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}