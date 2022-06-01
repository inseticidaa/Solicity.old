using Solicity.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solicity.Domain.Entities
{
    public class Request : BaseEntity
    {
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int RequestTypeId { get; set; }
        public virtual RequestType RequestType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public RequestStatusEnum Status { get; set; }
    }
}