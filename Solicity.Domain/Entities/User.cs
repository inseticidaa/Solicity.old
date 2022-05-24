using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Solicity.Domain.Entities
{
    [Table("TB_USERS")]
    public class User : BaseEntity
    {

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public bool Enabled { get; set; } = true;

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [JsonIgnore]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Required]
        [MinLength(8)]
        [JsonIgnore]
        public string Hash { get; set; }

        [Required]
        public bool IsAdmin { get; set; } = false;

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        public string Password
        {
            set
            {
                Hash = BCrypt.Net.BCrypt.HashPassword(value);
            }
        }

        public bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Hash);
        }

    }
}