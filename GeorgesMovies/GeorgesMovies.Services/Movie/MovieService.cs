using GeorgesMovies.Data;
using GeorgesMovies.Services.Interfaces;

namespace GeorgesMovies.Services.Movie
{
    public class MovieService : IMovieService
    {
        private readonly GeorgesMoviesDbContext context;
        public MovieService(GeorgesMoviesDbContext context)
        {
            this.context = context;
        }
    }
}
