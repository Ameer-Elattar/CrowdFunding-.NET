using Crowd_Funding.Repositories.Generic;

namespace Crowd_Funding.Repositories
{
    public class ReportRepository : GenericRepository<Report>, IReportRepository
    {
        public ReportRepository(CrowdFundingContext _context) : base(_context)
        {

        }
    }
}
