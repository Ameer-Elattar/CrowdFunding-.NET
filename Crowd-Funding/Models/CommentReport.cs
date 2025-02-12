using System.ComponentModel.DataAnnotations.Schema;

namespace Crowd_Funding.Models
{
    public class CommentReport
    {
        public int Id { get; set; }
        public string Content { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public ApplicationUser? User { get; set; }

        [ForeignKey("Comment")]
        public int CommentID { get; set; }
        public Comment? Comment { get; set; }
    }
}
