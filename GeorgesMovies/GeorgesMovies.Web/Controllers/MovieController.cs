using GeorgesMovies.Data;
using GeorgesMovies.Models.Models;
using GeorgesMovies.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GeorgesMovies.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly GeorgesMoviesDbContext context;
        public MovieController(GeorgesMoviesDbContext context)
        {
            this.context = context;
        }
        public IActionResult Add()
        {
            return View(new AddMovieFormModel
            {
                Genres = GetGenres()
            });
        }
        public IActionResult Manage()
        {
            return View(new ManageListingViewModel()
            {
                ManageList = this.ManageList()
            });
        }
        public IActionResult ManageT()
        {
            return RedirectToAction("Add");
        }
        [HttpPost]
        public IActionResult Add(AddMovieFormModel movie)
        {
            if (this.context.Movies.Any(m => m.Title == movie.Title))
            {
                this.ModelState.AddModelError(string.Empty, "This is movie is already added.");
            }

            if (!ModelState.IsValid)
            {
                movie.Genres = GetGenres();
                return View(movie);
            }
            var director = new Director()
            {
                FirstName = movie.Director.Split()[0],
                LastName = movie.Director.Split()[1]
            };
            var movieData = new Movie
            {
                Title = movie.Title,
                Time = movie.Time,
                MovieUrl = movie.MovieUrl,
                PictureUrl = movie.PictureUrl,
                GenreId = movie.GenreId,
                Overview = movie.Overview,
                Rating = movie.Rating,
                ReleaseInfo = movie.ReleaseInfo,
                Review = movie.Review
            };

            var splittedActors = movie.Actors
                .Split(new string[] {", ","," },System.StringSplitOptions
                .RemoveEmptyEntries);
            foreach (var currActor in splittedActors)
            {
                movieData.Actors.Add(new Actor { Name = currActor });
            }
            context.Directors.Add(director);
            movieData.Directors.Add(director);

            this.context.Movies.Add(movieData);
            this.context.SaveChanges();

            return RedirectToAction("Index","Home");
        }
        public IEnumerable<GenreFormViewModel> GetGenres()
        {
            return this.context
                .Genres
                .Select(g => new GenreFormViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToList();
        }
       
        public IEnumerable<ManageListingViewModel> ManageList()
        {
            var movies = this.context.Movies
                .Select(m => new ManageListingViewModel
                {
                    Title = m.Title,
                    Genre = m.Genre.Name,
                    Rating = m.Rating
                })
                .ToList();

            return movies;
        }
    }
}
