using GeorgesMovies.Models.Models;
using GeorgesMovies.Services.Comments;
using GeorgesMovies.Services.Comments.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [Authorize]
        [HttpPost]
        public IActionResult Post(CommentServiceModel model)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            this.comments.Create(userId, model);

            return RedirectToAction("Details","Movie",new {id = model.MovieId });
        }
    }
}
