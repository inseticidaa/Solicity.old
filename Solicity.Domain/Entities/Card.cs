using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicity.Domain.Entities
{
    public class Card: BaseEntity
    {
        #region [Props]

        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [MaxLength(256)]
        public string? Description { get; set; }

        [ForeignKey("User")]
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }

        [ForeignKey("User")]
        public int? AssignedId { get; set; }
        public virtual User? Assigned { get; set; }

        [ForeignKey("Team")]
        public int? TeamId { get; set; }
        public virtual Team? Team { get; set; }

        #endregion [Props]
    }
}
