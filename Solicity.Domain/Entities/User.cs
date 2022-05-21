using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Solicity.Domain.Entities
{
    [Table("TB_USERS")]
    public class User : BaseEntity
    {
        #region [Props]

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [JsonIgnore]
        public string Hash { get; set; }

        [Required]
        public bool Enabled { get; set; } = true;

        [Required]
        public bool IsAdmin { get; set; } = false;

        public string Password
        {
            set
            {
                Hash = BCrypt.Net.BCrypt.HashPassword(value);
            }
        }

        [JsonIgnore]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        #endregion [Props]

        #region [Methods]

        public bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Hash);
        }

        #endregion
    }
}