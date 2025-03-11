using Crowd_Funding.Repositories.Generic;

namespace Crowd_Funding.Repositories
{
    public class CommentReportRepository : GenericRepository<CommentReport>, ICommentReportRepository
    {
        public CommentReportRepository(CrowdFundingContext _context) : base(_context)
        {

        }
    }
}
