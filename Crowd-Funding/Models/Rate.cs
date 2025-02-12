using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crowd_Funding.Models
{
    public class Rate
    {
        public int Id { get; set; }
        [Required]
        [Range(minimum: 1, maximum: 5, ErrorMessage = "Rate must be between 1 and 5.")]
        public int RateValue { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public ApplicationUser? User { get; set; }


        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public Project? Project { get; set; }
    }
}
