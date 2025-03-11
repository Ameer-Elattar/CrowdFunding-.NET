using System.ComponentModel.DataAnnotations.Schema;

namespace Crowd_Funding.Models
{
    public class ProjectPics
    {
        public int Id { get; set; }
        public string PicPath { get; set; }
        public bool IsMain { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project? Project { get; set; }
    }
}
