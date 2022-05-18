using Solicity.Domain.DTOs;
using Solicity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicity.Domain.Services
{
    public interface IAuthService
    {
        Task<TokenDTO> Login(string email, string password);
        Task<TokenDTO> Register(User newUser);
    }
}
