using Crowd_Funding.Repositories.Generic;

namespace Crowd_Funding.Repositories
{
    public class RateRepository : GenericRepository<Rate>, IRateRepository
    {
        public RateRepository(CrowdFundingContext _context) : base(_context)
        {

        }
    }
}
