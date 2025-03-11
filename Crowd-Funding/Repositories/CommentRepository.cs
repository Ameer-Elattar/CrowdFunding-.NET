using Crowd_Funding.Repositories.Generic;

namespace Crowd_Funding.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(CrowdFundingContext _context) : base(_context)
        {

        }
    }
}
