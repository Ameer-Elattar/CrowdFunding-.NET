using System.ComponentModel.DataAnnotations;

namespace Crowd_Funding.DTO
{
    public class UpdateDonationDTO
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "Donation amount must be greater than 0.")]
        public decimal? Amount { get; set; }
        [RegularExpression("Pending|Completed|Cancelled")]
        public Status? Status { get; set; }
    }
}
