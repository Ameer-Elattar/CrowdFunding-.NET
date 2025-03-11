using System.ComponentModel.DataAnnotations;

namespace Crowd_Funding.DTO
{
    public class AddReportDTO
    {
        [Required]
        public string Content { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
    }
}
