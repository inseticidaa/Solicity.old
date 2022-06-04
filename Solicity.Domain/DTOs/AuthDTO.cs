using System.ComponentModel.DataAnnotations;
using Solicity.Domain.Entities;

namespace Solicity.Domain.DTOs;

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

public class RegisterDTO
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}

public class AuthenticateDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}