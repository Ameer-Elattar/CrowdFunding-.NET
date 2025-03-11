using System.ComponentModel.DataAnnotations;

namespace Crowd_Funding.DTO
{
    public class UpdateProjectDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public decimal? TargetMoney { get; set; }
        public Status? Status { get; set; }
        public int? CategoryID { get; set; }
        public int? UserID { get; set; }
        public List<IFormFile>? Files { get; set; }

    }
}
