using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crowd_Funding.Models
{
    public class Donation
    {
        public int Id { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Donation amount must be greater than 0.")]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public Status Status { get; set; }


        [ForeignKey("User")]
        public int UserID { get; set; }
        public ApplicationUser? User { get; set; }


        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public Project? Project { get; set; }

    }
}
