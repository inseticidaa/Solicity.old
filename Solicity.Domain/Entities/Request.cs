using System.ComponentModel.DataAnnotations.Schema;

namespace Solicity.Domain.Entities
{
    public class Request : BaseEntity
    {
        public int AuthorId { get; set; }
        public int TeamId { get; set; }
        public int RequestTypeId { get; set; }
        public virtual RequestType RequestType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Resolved { get; set; } = false;
    }
}