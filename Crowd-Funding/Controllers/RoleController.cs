using Crowd_Funding.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Crowd_Funding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<ApplicationRole> roleManager;

        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult getRoles()
        {
            return Ok(roleManager.Roles.ToList());
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleDTO requestRole)
        {
            ApplicationRole role = new();
            role.Name = requestRole.Name;
            IdentityResult result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
                return Ok(new { message = $"Role {requestRole.Name} Created" });
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("error", item.Description);
            }
            return BadRequest(ModelState);
        }
    }
}
