using System;
using System.Collections.Generic;

namespace GeorgesMovies.Services.Comments
{
    public class DetailCommentViewModel
    {
        public IEnumerable<AllCommentsViewModel> Comments { get; set; }
    }
}
