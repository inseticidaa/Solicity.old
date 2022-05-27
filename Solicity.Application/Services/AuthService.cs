using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Solicity.Domain.DTOs;
using Solicity.Domain.DTOs.Auth;
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

        private IConfiguration _configuration;
        private IUnitOfWork _unitOfWork;
        private ILogger _logger;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _logger = logger;
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
                    new Claim(ClaimTypes.Name, user.FullName),
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

        public async Task<TokenDTO> Login(LoginDTO loginDTO)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByEmailAsync(loginDTO.Email);

                if (user == null) throw new Exception("User not exists");

                if (!user.CheckPassword(loginDTO.Password)) throw new UnauthorizedAccessException();

                return GenerateToken(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TokenDTO> Register(RegisterDTO registerDTO)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByEmailAsync(registerDTO.Email);
                if (user != null) throw new Exception("User already registered");

                var newUser = new User
                {
                    FirstName = registerDTO.FirstName,
                    LastName = registerDTO.LastName,
                    Email = registerDTO.Email,
                    Password = registerDTO.Password,
                    Enabled = true,
                    IsAdmin = false,
                    CreatedAt = DateTime.Now,
                    UdpatedAt = DateTime.Now,
                };

                var user_id = await _unitOfWork.Users.AddAsync(newUser);
                var _user = await _unitOfWork.Users.GetByIdAsync(user_id);

                return GenerateToken(_user);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}