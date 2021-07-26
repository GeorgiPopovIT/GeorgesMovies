using GeorgesMovies.Data;
using GeorgesMovies.Models.Models;
using GeorgesMovies.Services.Movies;
using GeorgesMovies.Web.Models;
using GeorgesMovies.Web.Models.Actors;
using GeorgesMovies.Web.Models.Movies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GeorgesMovies.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly GeorgesMoviesDbContext context;
        private readonly IMovieService movies;
        public MovieController(GeorgesMoviesDbContext context, IMovieService movies)
        {
            this.context = context;
            this.movies = movies;
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
        public IActionResult Manage()
        {
            var manage = this.movies.Manage();

            return View(manage);

        }
        public IActionResult Add()
        {
            return View(new MovieServiceFormModel
            {
                Genres = this.movies.GetGenres()
            });
        }

        [HttpPost]
        public IActionResult Add(MovieServiceFormModel movie)
        {
            if (this.movies.IsMovieExist(movie))
            {
                this.ModelState.AddModelError(nameof(movie.Title),"This movie is already added.");
            }

            if (!ModelState.IsValid)
            {
                movie.Genres = this.movies.GetGenres();
                return View(movie);
            }

            this.movies.Add(movie);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Details(int id)
        {
            var detailQuery = this.movies.Details(id);

            return View(detailQuery);
        }

        public IActionResult Edit(int id)
        {
            var currMovie = this.movies.GetMovieById(id);
            currMovie.Genres = this.movies.GetGenres();

            return View(currMovie);
        }
        [HttpPost]
        public IActionResult Edit(int id, MovieServiceFormModel movie)
        {
            var editMovie = this.movies.Edit(id, movie);
            if (!editMovie || !ModelState.IsValid)
            {
                IActionResult actionResult = Edit(id);
                return base.RedirectToAction(nameof(actionResult));
            }
            return RedirectToAction(nameof(Manage));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            this.movies.Delete(id);

            return RedirectToAction(nameof(Manage));
        }
    }
}
