using Crowd_Funding.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Crowd_Funding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;

        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            this.userManager = userManager;
            this.config = config;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO requestUser)
        {
            ApplicationUser user = new()
            {
                UserName = requestUser.UserName,
                Email = requestUser.Email,
            };
            IdentityResult userResult = await userManager.CreateAsync(user, requestUser.Password);
            if (userResult.Succeeded)
            {
                IdentityResult result = await userManager.AddToRoleAsync(user, "User");
                if (result.Succeeded)
                    return Ok(new { message = "Account Created Successfully" });
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("error", item.Description);
                }
            }
            foreach (var item in userResult.Errors)
            {
                ModelState.AddModelError("error", item.Description);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO requestUser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser DBUser = await userManager.FindByNameAsync(requestUser.UserName);
                if (DBUser != null)
                {
                    bool isPassCorrect = await userManager.CheckPasswordAsync(DBUser, requestUser.Password);
                    if (isPassCorrect)
                    {

                        List<Claim> userClaims = new();
                        userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        userClaims.Add(new Claim(ClaimTypes.NameIdentifier, DBUser.Id.ToString()));
                        userClaims.Add(new Claim(ClaimTypes.Name, DBUser.UserName));
                        var UserRoles = await userManager.GetRolesAsync(DBUser);
                        foreach (var roleName in UserRoles)
                        {
                            userClaims.Add(new Claim(ClaimTypes.Role, roleName));
                        }
                        var signKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecretKey"]));
                        var signingCred = new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256);

                        JwtSecurityToken myToken = new JwtSecurityToken(
                            audience: config["JWT:AudienceIP"],
                            issuer: config["JWT:IssuerIP"],
                            expires: DateTime.Now.AddHours(1),
                            claims: userClaims,
                            signingCredentials: signingCred
                            );

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(myToken),
                            expires = DateTime.Now.AddHours(1),
                        });

                    }
                }
                ModelState.AddModelError("error", "Username or Password is Invalid");
            }
            return BadRequest(ModelState);
        }

        [HttpGet("getUserInfo")]
        [Authorize]
        public IActionResult GetUserDetails()
        {
            return Ok(new { id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value });
        }

    }
}
