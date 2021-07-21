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
            return View(new AddMovieServiceModel
            {
                Genres = this.movies.GetGenres()
            });
        }

        [HttpPost]
        public IActionResult Add(AddMovieServiceModel movie)
        {
            if (this.context.Movies.Any(m => m.Title == movie.Title))
            {
                this.ModelState.AddModelError(string.Empty, "This is movie is already added.");
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
            //var currMovie = this.context.Movies.FirstOrDefault(m => m.Id == id);

            //var actors = this.context.Actors.Where(a => a.Movies.Contains(currMovie))
            //    .Select(a => new ActorsNamesViewModel {FirstName= a.FirstName,LastName = a.LastName })
            //    .ToList();

            //var director = this.context.Directors
            //    .Where(d => d.Movies.Contains(currMovie))
            //    .Select(d => new { Name = d.FirstName + " " + d.LastName })
            //    .FirstOrDefault();
               

            //return View(new DetailsMovieViewModel
            //{
            //    Id = id,
            //    MovieUrl = currMovie.MovieUrl,
            //    Review = currMovie.Review,
            //    Time = currMovie.Time,
            //    Title = currMovie.Title,
            //    Year = currMovie.ReleaseDate.Year,
            //    ActorNames = actors,
            //    DirectorName = director.Name
            //});
        }
    }
}
