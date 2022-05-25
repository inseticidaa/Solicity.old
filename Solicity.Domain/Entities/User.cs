using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Solicity.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public bool Enabled { get; set; } = true;
        public string FirstName { get; set; }
        public string Hash { get; set; }
        public bool IsAdmin { get; set; } = false;
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
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