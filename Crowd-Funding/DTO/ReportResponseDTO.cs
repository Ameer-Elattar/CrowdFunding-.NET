namespace Crowd_Funding.DTO
{
    public class ReportResponseDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
    }
}
