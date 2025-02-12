using Microsoft.AspNetCore.Identity;

namespace Crowd_Funding.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? Image { get; set; }
        public DateTime Birth_date { get; set; }
    }
}
