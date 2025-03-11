namespace Crowd_Funding.DTO
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
        public CategoryResponseDTO Category { get; set; }

        public List<Donation>? Donations { get; set; }
        public List<Rate>? Rates { get; set; }
        public List<Report>? Reports { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
