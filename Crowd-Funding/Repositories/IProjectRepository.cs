using Crowd_Funding.Repositories.Generic;

namespace Crowd_Funding.Repositories
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        public List<ProjectWithIncludeDTO> GetProjectWithInclude();
        public ProjectResponseDTO GetProjectFullData(int id);
    }
}
