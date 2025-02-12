using System.ComponentModel.DataAnnotations.Schema;

namespace Crowd_Funding.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TargetMoney { get; set; }
        [ForeignKey("Status")]
        public int StatusID { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public Status? Status { get; set; }
        public Category? Category { get; set; }
        public ApplicationUser? User { get; set; }
        public List<ProjectTag>? ProjectTags { get; set; }


    }
}
