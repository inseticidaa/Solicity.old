using Solicity.Domain.Entities;

namespace Solicity.Domain.DTOs
{
    public class TokenDTO : UserDTO
    {
        public string Token { get; set; }

        public static implicit operator TokenDTO(User user)
        {
            return new TokenDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Enabled = user.Enabled,
                IsAdmin = user.IsAdmin,
                CreatedAt = user.CreatedAt,
                UdpatedAt = user.UdpatedAt,
            };
        }
    }
}