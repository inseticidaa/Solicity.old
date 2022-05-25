using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solicity.Domain.Entities
{
    public class Team : BaseEntity
    {
        public string? Description { get; set; }
        public bool Enabled { get; set; } = true;
        public string Name { get; set; }
        public bool Public { get; set; }
    }
}