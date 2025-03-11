using Crowd_Funding.Repositories.Generic;

namespace Crowd_Funding.Repositories
{
    public class DonationRepository : GenericRepository<Donation>, IDonationRepository
    {
        public DonationRepository(CrowdFundingContext _context) : base(_context)
        {

        }
    }
}
