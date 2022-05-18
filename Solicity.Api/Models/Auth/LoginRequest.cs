using System.ComponentModel.DataAnnotations;

namespace Solicity.Api.Models.Auth
{
    public class LoginRequest
    {
        [Required]
        [MaxLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
