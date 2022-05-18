using System.ComponentModel.DataAnnotations;

namespace Solicity.Api.Models.Teams
{
    public class CreateTeamRequest
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(256)]
        public string? Description { get; set; }
    }
}
