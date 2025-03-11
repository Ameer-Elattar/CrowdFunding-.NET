using Crowd_Funding.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crowd_Funding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportService reportService;

        public ReportController(ReportService reportService)
        {
            this.reportService = reportService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllReports()
        {
            return Ok(await reportService.GetAllReportAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetReportById(int id)
        {
            var report = await reportService.GetReportByIdAsync(id);
            if (report == null) return NotFound(new { message = "Report Doesn't exist" });
            return Ok(report);
        }
        [HttpPost]
        public async Task<IActionResult> AddReport(AddReportDTO requestReport)
        {
            var report = await reportService.AddReportAsync(requestReport);
            return CreatedAtAction("GetReportById", new { id = report.Id }, report);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateReport(UpdateReportDTO requestReport, int id)
        {
            var isUpdated = await reportService.UpdateReportAsync(requestReport, id);
            if (isUpdated == false) return NotFound(new { message = "Report Doesn't exist" });
            return Ok(new { message = "Report Updated" });

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var isDeleted = await reportService.DeleteReportAsync(id);
            if (isDeleted == false) return NotFound(new { message = "Report Doesn't exist" });
            return Ok(new { message = "Report Deleted" });
        }
    }
}
