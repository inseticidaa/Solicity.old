namespace Solicity.Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; set; }
    public bool Enabled { get; set; } = true;
    public string FirstName { get; set; }
    public string Hash { get; set; }
    public bool IsAdmin { get; set; } = false;
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
