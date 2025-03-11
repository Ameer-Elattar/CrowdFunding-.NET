using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crowd_Funding.Models
{
    public class Report
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }


        [ForeignKey("User")]
        public int UserID { get; set; }
        public ApplicationUser? User { get; set; }


        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public Project? Project { get; set; }
    }
}
