using System.Collections.Generic;

namespace GeorgesMovies.Services.Comments.DTO
{
    public class DetailCommentViewModel
    {
        public IEnumerable<AllCommentsViewModel> Comments { get; set; }
    }
}
