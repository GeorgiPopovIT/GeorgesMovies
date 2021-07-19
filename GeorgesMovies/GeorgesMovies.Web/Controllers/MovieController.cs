using GeorgesMovies.Data;
using GeorgesMovies.Models.Models;
using GeorgesMovies.Web.Models;
using GeorgesMovies.Web.Models.Movies;
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
        public IActionResult All([FromQuery]AllMoviesViewModel query)
        {
            var moviesQuery = GetMoviesListing();

            if (!string.IsNullOrWhiteSpace(query.SearchItem))
            {
                moviesQuery = moviesQuery
                    .Where(m => m.Title.ToLower() == query.SearchItem.ToLower()
                    || m.Title.ToLower().Contains(query.SearchItem.ToLower()));
            }
            if (query.GenreId != 0)
            {
                moviesQuery = moviesQuery
                    .Where(g => g.GenreId == query.GenreId);
            }
            var genres = GetGenres();
            var movies = moviesQuery.ToList();


            return View(new AllMoviesViewModel
            {
                Movies = movies,
                SearchItem = query.SearchItem,
                Genres = genres
            });
        }
        public IActionResult Manage()
        {
            return View(new ManageListingViewModel()
            {
                ManageList = this.ManageList()
            });
        }
        public IActionResult Add()
        {
            return View(new AddMovieFormModel
            {
                Genres = GetGenres()
            });
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
                ReleaseDate = movie.ReleaseDate,
                Review = movie.Review
            };


            context.Directors.Add(director);
            movieData.Directors.Add(director);

            this.context.Movies.Add(movieData);
            this.context.SaveChanges();

            return RedirectToAction(nameof(All));
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

        public IQueryable<ListMoviesViewModel> GetMoviesListing()
        {
            var movies = this.context.Movies
                .Select(m => new ListMoviesViewModel
                {
                    Id = m.Id,
                    GenreId = m.GenreId,
                    PictureId = m.PictureUrl,
                    Title = m.Title,
                    Overview = m.Overview
                })
                .AsQueryable();

            return movies;
        }
    }
}
