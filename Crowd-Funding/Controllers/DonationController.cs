using Crowd_Funding.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crowd_Funding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly DonationService donationService;

        public DonationController(DonationService donationService)
        {
            this.donationService = donationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDonations()
        {
            var donations = await donationService.GetAllDonationAsync();

            return Ok(donations);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDonationByID(int id)
        {
            var donation = await donationService.GetDonationByIDAsync(id);
            if (donation == null) return NotFound(new { message = "Donation Doesn't exist" });

            return Ok(donation);
        }
        [HttpPost]
        public async Task<IActionResult> AddDonation(AddDonationDTO requestDonation)
        {
            DonationResponseDTO donation = await donationService.AddDonationAsync(requestDonation);
            return CreatedAtAction("GetDonationByID", new { id = donation.Id }, donation);
        }
        [HttpPut("{id:int}")]

        public async Task<IActionResult> UpdateDonation(UpdateDonationDTO requestDonation, int id)
        {
            bool isUpdated = await donationService.UpdateDonationAsync(requestDonation, id);
            if (isUpdated) return Ok(new { message = "Donation Updated" });
            return NotFound(new { message = "Donation Doesn't exist" });

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDonation(int id)
        {
            var isDeleted = await donationService.DeleteDonationAsync(id);
            if (isDeleted) return Ok(new { message = "Donation Deleted" });
            return NotFound(new { message = "Donation Doesn't exist" });

        }

    }
}
