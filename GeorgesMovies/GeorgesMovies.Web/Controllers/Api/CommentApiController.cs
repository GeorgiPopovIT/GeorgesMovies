using GeorgesMovies.Services.Comments;
using GeorgesMovies.Services.Comments.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace GeorgesMovies.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentApiController : ControllerBase
    {
        private readonly ICommentService comments;

        public CommentApiController(ICommentService comments)
        {
            this.comments = comments;
        }

        [Authorize]
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public ActionResult Post(CommentServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AllByMovie", "Comment",
                    new { movieId = model.MovieId });
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            this.comments.Create(userId, model);

            return RedirectToAction("AllByMovie", "Comment",
            new { movieId = model.MovieId });
        }
    }
}
