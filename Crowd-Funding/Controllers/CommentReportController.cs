using Crowd_Funding.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crowd_Funding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentReportController : ControllerBase
    {
        private readonly CommentReportService commentReportService;

        public CommentReportController(CommentReportService commentReportService)
        {
            this.commentReportService = commentReportService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            return Ok(await commentReportService.GetAllCommentsAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var commentReport = await commentReportService.GetCommentByIDAsync(id);
            if (commentReport == null) return NotFound(new { message = "Comment Report Doesn't exist" });
            return Ok(commentReport);
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(AddCommentReportDTO requestComment)
        {
            var commentReport = await commentReportService.AddCommentAsync(requestComment);
            return CreatedAtAction("GetCommentById", new { id = commentReport.Id }, commentReport);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateComment(UpdateCommentReportDTO requestComment, int id)
        {
            bool isUpdated = await commentReportService.UpdateCommentAsync(requestComment, id);
            if (isUpdated == true) return Ok(new { message = "Comment Report Updated" });
            return NotFound(new { message = "Comment Report Doesn't exist" });
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            bool isDeleted = await commentReportService.DeleteComment(id);
            if (isDeleted == true) return Ok(new { message = "Comment Report Deleted" });
            return NotFound(new { message = "Comment Report Doesn't exist" });
        }
    }
}
