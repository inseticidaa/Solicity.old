using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Solicity.Domain.DTOs;
using Solicity.Domain.Entities;
using Solicity.Domain.Ports;
using Solicity.Domain.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Solicity.Application.Services
{
    public class AuthService : IAuthService
    {
        #region [Props]

        private IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        #endregion [Props]

        #region [Methods]

        public async Task<TokenDTO> Login(string email, string password)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByEmail(email);

                if (user == null) throw new Exception("User not exists");

                if (!user.CheckPassword(password)) throw new Exception("Unauthorized");

                return GenerateToken(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TokenDTO> Register(User newUser)
        {
            try
            {
                var exits = await _unitOfWork.Users.CountWhere(u => u.Email == newUser.Email);

                if (exits > 0)
                {
                    throw new Exception("User already registered");
                }

                await _unitOfWork.Users.Add(newUser);
                var user = await _unitOfWork.Users.GetByEmail(newUser.Email);

                return GenerateToken(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TokenDTO GenerateToken(User user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User"),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var _token = (TokenDTO)user;
            _token.Token = tokenHandler.WriteToken(token);

            return _token;
        }

        #endregion [Methods]
    }
}