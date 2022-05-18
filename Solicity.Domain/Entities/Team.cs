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
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool Enabled { get; set; }

        #endregion [Props]
    }
}