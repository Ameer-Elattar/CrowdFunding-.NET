using Crowd_Funding.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crowd_Funding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly RateService rateService;

        public RateController(RateService rateService)
        {
            this.rateService = rateService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRates()
        {
            return Ok(await rateService.GetAllRateAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRateById(int id)
        {
            var rate = await rateService.GetRateByIdAsync(id);
            if (rate == null) return NotFound(new { message = "Rate Doesn't exist" });
            return Ok(rate);
        }
        [HttpPost]
        public async Task<IActionResult> AddRate(AddRateDTO requestRate)
        {
            var rate = await rateService.AddRateAsync(requestRate);
            return CreatedAtAction("GetRateById", new { id = rate.Id }, rate);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRate(UpdateRateDTO requestRate, int id)
        {
            var isUpdated = await rateService.UpdateRateAsync(requestRate, id);
            if (isUpdated == false) return NotFound(new { message = "Rate Doesn't exist" });
            return Ok(new { message = "Rate Updated" });

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRate(int id)
        {
            var isDeleted = await rateService.DeleteRateAsync(id);
            if (isDeleted == false) return NotFound(new { message = "Rate Doesn't exist" });
            return Ok(new { message = "Rate Deleted" });
        }
    }
}
