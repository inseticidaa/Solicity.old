using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicity.Domain.Entities
{
    [Table("TB_TEAMS_MEMBERS")]
    public class TeamMember: BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public bool IsOwner { get; set; } = false;
    }
}
