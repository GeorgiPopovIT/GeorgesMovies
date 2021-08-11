using GeorgesMovies.Data;
using GeorgesMovies.Services.Movies;
using System.Collections.Generic;
using System.Linq;

namespace GeorgesMovies.Services.Home
{
    public class HomeService : IHomeService
    {
        private readonly GeorgesMoviesDbContext context;

        public HomeService(GeorgesMoviesDbContext context)
        {
            this.context = context;
        }
        public List<IndexMovieViewModel> GetLastThreeMovies()
        {
            var movies = this.context.Movies
                 .OrderByDescending(m => m.Id)
                 .Select(m => new IndexMovieViewModel
                 {
                     PictuteUrl = m.PictureUrl,
                     Title = m.Title
                 }) 
                 .Take(3)
                 .ToList();

            return movies;
        }
    }
}
