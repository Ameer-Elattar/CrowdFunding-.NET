using Crowd_Funding.DTO.Category;

namespace Crowd_Funding.DTO.Project
{
    public class ProjectWithIncludeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TargetMoney { get; set; }
        public Status Status { get; set; }
        public GetCategoryDTO Category { get; set; }

        public List<ProjectTag>? ProjectTags { get; set; }
        public List<Donation>? Donations { get; set; }
        public List<Rate>? Rates { get; set; }
        public List<Report>? Reports { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
