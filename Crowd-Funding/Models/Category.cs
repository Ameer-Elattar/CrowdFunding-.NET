namespace Crowd_Funding.Models
{
    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Discription { get; set; }

        public List<Project>? projects { get; set; }
    }
}
