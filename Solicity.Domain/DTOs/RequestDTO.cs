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
        public DateTime CreatedAt { get; set; }
        public DateTime UdpatedAt { get; set; }
    }

    public class RequestDetailDTO
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public UserDTO Author { get; set; }
        public int TeamId { get; set; }
        public TeamDTO Team { get; set; }
        public int RequestTypeId { get; set; }
        public RequestTypeDTO RequestType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Resolved { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UdpatedAt { get; set; }
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
        public int RequestTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
