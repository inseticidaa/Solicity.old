namespace Solicity.Domain.DTOs
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int TeamId { get; set; }
        public int RequestTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Resolved { get; set; }
    }

    public class NewRequestDTO
    {
        public int RequestTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<int> Stakeholders { get; set; }
    }
    public class EditRequestDTO
    {

    }
}
