namespace Solicity.Domain.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Enabled { get; set; }
        public bool Public { get; set; }
    }
}