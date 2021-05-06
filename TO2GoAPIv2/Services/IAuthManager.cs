using TO2GoAPIv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TO2GoAPIv2.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO userDTO);
        Task<string> CreateToken();
    }
}
