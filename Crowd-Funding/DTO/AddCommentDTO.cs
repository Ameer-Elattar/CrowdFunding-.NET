namespace Crowd_Funding.DTO
{
    public class AddCommentDTO
    {
        public string Content { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
    }
}
