using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Crowd_Funding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]

        public IActionResult getUsers()
        {
            return Ok(userManager.Users.Select(user =>
            new
            {
                user.Id,
                user.UserName,
                user.NormalizedUserName,
                user.NormalizedEmail
            }).ToList());
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUserAsync(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user == null)
            {

                return NotFound(new { error = "User not found" });
            }
            IdentityResult result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(new { error = "Failed to delete user", details = result.Errors });
            }
            return Ok(new { message = "User Deleted" });
        }
    }
}
