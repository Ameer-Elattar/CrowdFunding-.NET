
using Crowd_Funding.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Crowd_Funding.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProjectRepository(CrowdFundingContext _context, IHttpContextAccessor httpContextAccessor) : base(_context)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public ProjectResponseDTO GetProjectFullData(int id)
        {
            var project = table.Include(p => p.Category).Include(p => p.Tags)
                .Include(p => p.User).Include(p => p.ImagePaths).FirstOrDefault(p => p.Id == id);
            if (project == null) return null;
            var request = httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host.Value}";
            return new ProjectResponseDTO
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                TargetMoney = project.TargetMoney,
                Status = project.Status,

                Tags = project?.Tags?.Select(tag => new TagResponseDTO
                {
                    Id = tag.Id,
                    Name = tag.Name
                }).ToList(),
                Category = new CategoryResponseDTO
                {
                    Id = project.Category.Id,
                    Name = project.Category.Name
                },
                User = new UserResponseDTO
                {
                    Id = project.User.Id,
                    UserName = project.User.UserName,
                    Email = project.User.Email
                },
                ImagePaths = project?.ImagePaths?.Select(path => $"{baseUrl}/{path.PicPath}").ToList(),

            };
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
                Category = new CategoryResponseDTO
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name,
                    Description = p.Category.Description
                },

            }).ToList();
        }

    }
}
