using GeorgesMovies.Services.Genres;
using GeorgesMovies.Services.Movies;
using GeorgesMovies.Services.Movies.DTO;
using GeorgesMovies.Web.Models.Movies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeorgesMovies.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IGenreService genres;
        private readonly IMovieService movies;
        public MovieController(IMovieService movies, IGenreService genres)
        {
            this.movies = movies;
            this.genres = genres;
        }

        public IActionResult All([FromQuery] AllMoviesViewModel query)
        {
            var moviesQuery = this.movies.All(
                query.SearchItem,
                query.CurrentPage,
                AllMoviesViewModel.MoviesPerPage,
                query.GenreId
                );

            query.TotalMovies = moviesQuery.TotalMovies;
            query.Movies = moviesQuery.Movies;
            query.Genres = moviesQuery.Genres;

            return View(query);

        }

        [Authorize]
        public IActionResult Manage()
        {
            var manage = this.movies.Manage();

            return View(manage);

        }

        [Authorize]
        public IActionResult Add()
        {
            return View(new MovieServiceFormModel
            {
                Genres = this.genres.GetGenres()
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(MovieServiceFormModel movie)
        {
            if (this.movies.IsMovieExist(movie))
            {
                this.ModelState.AddModelError(nameof(movie.Title), "This movie is already added.");
            }

            if (!ModelState.IsValid)
            {
                movie.Genres = this.genres.GetGenres();
                return View(movie);
            }

            this.movies.Add(movie);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var detailQuery = this.movies.Details(id);
            return View(detailQuery);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var currMovie = this.movies.GetMovieById(id);
            currMovie.Genres = this.genres.GetGenres();

            return View(currMovie);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, MovieServiceFormModel movie)
        {
            var editMovie = this.movies.Edit(id, movie);
            if (!editMovie || !ModelState.IsValid)
            {
                return RedirectToAction(nameof(Edit));
            }
            return RedirectToAction(nameof(Manage));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            this.movies.Delete(id);

            return RedirectToAction(nameof(Manage));
        }
    }
}
