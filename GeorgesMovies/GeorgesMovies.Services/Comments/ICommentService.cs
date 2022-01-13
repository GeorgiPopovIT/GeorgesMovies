using GeorgesMovies.Services.Comments.DTO;
using System.Collections.Generic;

namespace GeorgesMovies.Services.Comments
{
    public interface ICommentService
    {
        void Create(string userId, CommentServiceModel model);

        DetailCommentViewModel All(int movieId);

        IEnumerable<AllCommentsViewModel> GetAllComments(int movieId);

        void Delete(int id);

        int GetMovieIdByCommentId(int id);
    }
}
