namespace Crowd_Funding.Services
{
    public class CommentReportService
    {
        private readonly ICommentReportRepository commentReportRepository;

        public CommentReportService(ICommentReportRepository commentReportRepository)
        {
            this.commentReportRepository = commentReportRepository;
        }
        public async Task<IEnumerable<CommentReportResponseDTO>> GetAllCommentsAsync()
        {
            var commentReports = await commentReportRepository.GetAllAsync();
            return commentReports.Select(commentReport => new CommentReportResponseDTO
            {
                Id = commentReport.Id,
                Content = commentReport.Content,
                UserID = commentReport.UserID,
                CommentID = commentReport.CommentID
            });
        }

        public async Task<CommentReportResponseDTO> GetCommentByIDAsync(int id)
        {
            CommentReport commentReport = await commentReportRepository.GetByIdAsync(id);
            if (commentReport == null) return null;
            return new CommentReportResponseDTO
            {
                Id = commentReport.Id,
                Content = commentReport.Content,
                UserID = commentReport.UserID,
                CommentID = commentReport.CommentID
            };
        }

        public async Task<CommentReportResponseDTO> AddCommentAsync(AddCommentReportDTO requestComment)
        {
            var commentReport = new CommentReport
            {
                Content = requestComment.Content,
                UserID = requestComment.UserID,
                CommentID = requestComment.CommentID
            };
            await commentReportRepository.InsertAsync(commentReport);
            await commentReportRepository.SaveAsync();
            return new CommentReportResponseDTO
            {
                Id = commentReport.Id,
                Content = commentReport.Content,
                UserID = commentReport.UserID,
                CommentID = commentReport.CommentID
            };
        }

        public async Task<bool> UpdateCommentAsync(UpdateCommentReportDTO requestComment, int id)
        {
            CommentReport commentReport = await commentReportRepository.GetByIdAsync(id);
            if (commentReport == null) return false;
            commentReport.Content = requestComment.Content;
            commentReportRepository.Update(commentReport);
            await commentReportRepository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteComment(int id)
        {
            CommentReport commentReport = await commentReportRepository.GetByIdAsync(id);
            if (commentReport == null) return false;
            commentReportRepository.Delete(commentReport);
            await commentReportRepository.SaveAsync();
            return true;
        }
    }
}
