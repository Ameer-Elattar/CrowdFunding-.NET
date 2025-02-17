using Crowd_Funding.DTO.Project;

namespace Crowd_Funding.Repositories
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        public List<ProjectWithIncludeDTO> GetProjectWithInclude();
    }
}
