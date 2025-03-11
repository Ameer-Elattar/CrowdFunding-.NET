using Crowd_Funding.Repositories.Generic;

namespace Crowd_Funding.Repositories
{
    public interface IProjectPicsRepository : IGenericRepository<ProjectPics>
    {
        List<ProjectPics> GetProjectPics(int id);
    }
}
