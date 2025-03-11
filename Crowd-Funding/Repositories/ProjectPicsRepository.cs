using Crowd_Funding.Repositories.Generic;

namespace Crowd_Funding.Repositories
{
    public class ProjectPicsRepository : GenericRepository<ProjectPics>, IProjectPicsRepository
    {
        public ProjectPicsRepository(CrowdFundingContext context) : base(context)
        {

        }

        public List<ProjectPics> GetProjectPics(int id)
        {
            return table.Where(pp => pp.ProjectId == id).ToList();
        }
    }
}
