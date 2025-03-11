namespace Crowd_Funding.DTO
{
    public class CommentResponseDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int UserID { get; set; }
        public int? ProjectID { get; set; }
    }
}
