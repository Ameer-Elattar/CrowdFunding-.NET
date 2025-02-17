
using Crowd_Funding.DTO.Category;
using Crowd_Funding.DTO.Project;
using Microsoft.EntityFrameworkCore;

namespace Crowd_Funding.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(CrowdFundingContext _context) : base(_context)
        {
        }

        public List<ProjectWithIncludeDTO> GetProjectWithInclude()
        {
            var projects = table.Include(p => p.Category).ToList();

            return projects.Select(p => new ProjectWithIncludeDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                TargetMoney = p.TargetMoney,
                Status = p.Status,
                Category = new GetCategoryDTO
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name,
                    Description = p.Category.Description
                },

            }).ToList();
        }

    }
}
