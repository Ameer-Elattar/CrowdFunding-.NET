using Crowd_Funding.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crowd_Funding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly TagService tagService;

        public TagController(TagService tagService)
        {
            this.tagService = tagService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await tagService.GetAllTagsAsync();
            return Ok(tags);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTagByID(int id)
        {
            var tag = await tagService.GetTagByIdAsync(id);
            if (tag == null)
            {
                return NotFound(new { message = "Tag Doesn't exist" });
            }
            return Ok(tag);
        }
        [HttpPost]
        public async Task<IActionResult> AddTag(AddTagDTO requestTag)
        {
            var tag = await tagService.AddTagAsync(requestTag);

            return CreatedAtAction(nameof(GetTagByID), new { id = tag.Id }, tag);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTag(AddTagDTO requestTag, int id)
        {
            var isUpdated =
                await tagService.UpdateTagAsync(requestTag, id);
            if (isUpdated != true)
                return NotFound(new { message = "Tag Doesn't exist" });
            return Ok(new { message = "Tag Updated" });

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var isDeleted = await tagService.DeleteTagAsync(id);
            if (isDeleted != true)
                return NotFound(new { message = "Tag Doesn't exist" });
            return Ok(new { message = "Tag Deleted" });
        }
    }
}
