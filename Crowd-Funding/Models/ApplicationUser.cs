using Microsoft.AspNetCore.Identity;

namespace Crowd_Funding.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? Image { get; set; }
        public DateTime Birth_date { get; set; }
        public List<Project>? Projects { get; set; }
        public List<Donation>? Donations { get; set; }
        public List<Rate>? Rates { get; set; }
        public List<Report>? Reports { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<CommentReport>? CommentReports { get; set; }
    }
}
