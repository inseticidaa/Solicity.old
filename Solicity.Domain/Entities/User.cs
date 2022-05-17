using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Hash { get; set; }

        [Required]
        public bool Enabled { get; set; }

        public string Password
        {
            set
            {
                Hash = BCrypt.Net.BCrypt.HashPassword(value);
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