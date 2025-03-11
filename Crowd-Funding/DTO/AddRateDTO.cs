using System.ComponentModel.DataAnnotations;

namespace Crowd_Funding.DTO
{
    public class AddRateDTO
    {
        [Required]
        [Range(minimum: 1, maximum: 5, ErrorMessage = "Rate must be between 1 and 5.")]
        public int RateValue { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
    }
}
