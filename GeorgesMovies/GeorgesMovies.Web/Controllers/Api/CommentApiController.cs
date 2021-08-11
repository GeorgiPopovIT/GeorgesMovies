using GeorgesMovies.Services.Comments;
using Microsoft.AspNetCore.Mvc;

namespace GeorgesMovies.Web.Controllers.Api
{
    [ApiController]
    [Route("api/comment")]
    public class CommentApiController  :ControllerBase
    {
        private readonly ICommentService comments;

        public CommentApiController(ICommentService comments)
        {
            this.comments = comments;
        }
        [HttpPost]
        public IActionResult Post()
        {
            return null;        
        }
    }
}
