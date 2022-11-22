using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Identity;

namespace Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user, string role);
    }
}