using System.ComponentModel.DataAnnotations;

namespace Crowd_Funding.DTO
{
    public class AddProjectDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public decimal TargetMoney { get; set; }
        public Status Status { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }
        public List<int> TagIDs { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
