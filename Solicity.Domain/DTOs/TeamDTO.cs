using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicity.Domain.DTOs
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool Enabled { get; set; } = true;
        public string Name { get; set; }
        public bool Public { get; set; }

        public static implicit operator TeamDTO(Entities.Team team)
        {
            var dto = new TeamDTO
            {
                Id = team.Id,
                Description = team.Description,
                Enabled = team.Enabled,
                Public = team.Public,
            };

            return dto;
        }
    }

    public class NewTeamDTO
    {
        public string? Description { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Public { get; set; }
    }

    public class EditTeamDTO
    {
        public string? Description { get; set; }
        public bool Enabled { get; set; } = true;
        public string Name { get; set; }
        public bool Public { get; set; }
    }
}
