using System.ComponentModel.DataAnnotations;

namespace Crowd_Funding.DTO.Category
{
    public class AddCategoryDTO
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
