using Crowd_Funding.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crowd_Funding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentService commentService;

        public CommentController(CommentService commentService)
        {
            this.commentService = commentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            return Ok(await commentService.GetAllCommentsAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await commentService.GetCommentByIDAsync(id);
            if (comment == null) return NotFound(new { message = "Comment Doesn't exist" });
            return Ok(comment);
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(AddCommentDTO requestComment)
        {
            var comment = await commentService.AddCommentAsync(requestComment);
            return CreatedAtAction("GetCommentById", new { id = comment.Id }, comment);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateComment(UpdateCommentDTO requestComment, int id)
        {
            bool isUpdated = await commentService.UpdateCommentAsync(requestComment, id);
            if (isUpdated == true) return Ok(new { message = "Comment Updated" });
            return NotFound(new { message = "Comment Doesn't exist" });
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            bool isDeleted = await commentService.DeleteComment(id);
            if (isDeleted == true) return Ok(new { message = "Comment Deleted" });
            return NotFound(new { message = "Comment Doesn't exist" });
        }


    }
}
