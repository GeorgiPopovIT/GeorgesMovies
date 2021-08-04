using GeorgesMovies.Services.Comments;
using GeorgesMovies.Services.Movies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GeorgesMovies.Web.Controllers
{
    //[ApiController]
    //[Route("api/comment")]
    public class CommentController : Controller
    {
        private readonly ICommentService comments;
        public CommentController(ICommentService comments)
        {
            this.comments = comments;
        }
       
        [HttpPost]
        public IActionResult Post(CommentServiceModel model)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
                
            this.comments.Create(userId,model);

             return RedirectToAction("Details",
                 "Movie",new {id = model.MovieId });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var movieId = this.comments.GetMovieIdByCommentId(id);

            this.comments.Delete(id);

            return RedirectToAction("Details",
                 "Movie", new { id = movieId }) ;
        }
    }
}
