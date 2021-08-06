using GeorgesMovies.Services.Movies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GeorgesMovies.Web.Areas.Admin.Controllers
{
    public class MovieController : AdminController
    {
        private readonly IMovieService movies;

        public MovieController(IMovieService movies)
        {
            this.movies = movies;
        }

       
        [Authorize]
        public IActionResult Manage()
        {
            var manage = this.movies.Manage();

            return View(manage);

        }
    }
}
