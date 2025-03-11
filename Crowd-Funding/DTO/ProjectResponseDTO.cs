namespace Crowd_Funding.DTO
{
    public class ProjectResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TargetMoney { get; set; }
        public Status Status { get; set; }
        public CategoryResponseDTO? Category { get; set; }
        public UserResponseDTO? User { get; set; }
        public List<TagResponseDTO>? Tags { get; set; }
        public List<Donation>? Donations { get; set; }
        public List<Rate>? Rates { get; set; }
        public List<Report>? Reports { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<string>? ImagePaths { get; set; }
    }
}
