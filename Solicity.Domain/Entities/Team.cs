using Solicity.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solicity.Domain.Entities
{
    [Table("TB_TEAMS")]
    public class Team : BaseEntity
    {
        #region [Props]

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(256)]
        public string? Description { get; set; }

        [Required]
        public bool Enabled { get; set; } = true;

        [Required]
        public VisibilityEnum Visibility { get; set; }

        public virtual ICollection<TeamMember> Members { get; set; }

        #endregion [Props]
    }
}