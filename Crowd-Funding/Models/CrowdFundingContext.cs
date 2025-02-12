using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Crowd_Funding.Models
{
    public class CrowdFundingContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {


        public CrowdFundingContext(DbContextOptions<CrowdFundingContext> options) : base(options)
        {

        }
    }
}
