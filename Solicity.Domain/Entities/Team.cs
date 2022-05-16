using System.ComponentModel.DataAnnotations;

namespace Solicity.Domain.Entities
{
    public class Team : BaseEntity
    {
        #region [Props]

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(256)]
        public string? Description { get; set; }

        #endregion [Props]
    }
}