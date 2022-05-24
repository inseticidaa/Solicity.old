using Solicity.Domain.Entities;

namespace Solicity.Domain.DTOs
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public User Author { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UdpatedAt { get; set; }

        public static implicit operator TeamDTO(Team team)
        {
            return new TeamDTO
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description,
                //Author = team.Author,
                Enabled = team.Enabled,
                CreatedAt = team.CreatedAt,
                UdpatedAt = team.UdpatedAt,
            };
        }
    }
}