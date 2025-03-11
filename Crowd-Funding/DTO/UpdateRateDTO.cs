using System.ComponentModel.DataAnnotations;

namespace Crowd_Funding.DTO
{
    public class UpdateRateDTO
    {
        [Required]
        [Range(minimum: 1, maximum: 5, ErrorMessage = "Rate must be between 1 and 5.")]
        public int? RateValue { get; set; }

    }
}
