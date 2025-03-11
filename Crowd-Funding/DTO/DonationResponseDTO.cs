namespace Crowd_Funding.DTO
{
    public class DonationResponseDTO
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
    }
}
