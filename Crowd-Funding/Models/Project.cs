using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crowd_Funding.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Compare(nameof(StartDate), ErrorMessage = "End date must be after start date.")]
        public DateTime EndDate { get; set; }
        public decimal TargetMoney { get; set; }
        public Status Status { get; set; }



        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category? Category { get; set; }


        [ForeignKey("User")]
        public int UserID { get; set; }
        public ApplicationUser? User { get; set; }


        public List<ProjectTag>? ProjectTags { get; set; }
        public List<Donation>? Donations { get; set; }
        public List<Rate>? Rates { get; set; }
        public List<Report>? Reports { get; set; }
        public List<Comment>? Comments { get; set; }



    }
}
