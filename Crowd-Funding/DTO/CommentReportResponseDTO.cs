namespace Crowd_Funding.DTO
{
    public class CommentReportResponseDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserID { get; set; }
        public int CommentID { get; set; }
    }
}
