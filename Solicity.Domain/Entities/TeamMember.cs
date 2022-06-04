namespace Solicity.Domain.Entities
{
    public class TeamMember : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int TeamId { get; set; }
    }
}