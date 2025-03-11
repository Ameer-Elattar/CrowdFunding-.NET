namespace Crowd_Funding.Services
{
    public class CommentService
    {
        private readonly ICommentRepository commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public async Task<IEnumerable<CommentResponseDTO>> GetAllCommentsAsync()
        {
            var comments = await commentRepository.GetAllAsync();
            return comments.Select(comment => new CommentResponseDTO
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                UserID = comment.UserID,
                ProjectID = comment.ProjectID
            });
        }

        public async Task<CommentResponseDTO> GetCommentByIDAsync(int id)
        {
            Comment comment = await commentRepository.GetByIdAsync(id);
            if (comment == null) return null;
            return new CommentResponseDTO
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                UserID = comment.UserID,
                ProjectID = comment.ProjectID
            };
        }

        public async Task<CommentResponseDTO> AddCommentAsync(AddCommentDTO requestComment)
        {
            var comment = new Comment
            {
                Content = requestComment.Content,
                UserID = requestComment.UserID,
                ProjectID = requestComment.ProjectID
            };
            await commentRepository.InsertAsync(comment);
            await commentRepository.SaveAsync();
            return new CommentResponseDTO
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                UserID = comment.UserID,
                ProjectID = comment.ProjectID
            };
        }

        public async Task<bool> UpdateCommentAsync(UpdateCommentDTO requestComment, int id)
        {
            Comment comment = await commentRepository.GetByIdAsync(id);
            if (comment == null) return false;
            comment.Content = requestComment.Content;
            commentRepository.Update(comment);
            await commentRepository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteComment(int id)
        {
            Comment comment = await commentRepository.GetByIdAsync(id);
            if (comment == null) return false;
            commentRepository.Delete(comment);
            await commentRepository.SaveAsync();
            return true;
        }
    }
}
