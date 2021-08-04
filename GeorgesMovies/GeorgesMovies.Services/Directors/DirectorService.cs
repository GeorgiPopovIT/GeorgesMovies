using GeorgesMovies.Data;
using GeorgesMovies.Models.Models;
using GeorgesMovies.Services.Directors.DTO;
using GeorgesMovies.Services.Movies.DTO;
using System.Linq;

namespace GeorgesMovies.Services.Directors
{
    public class DirectorService : IDirectorService
    {
        private readonly GeorgesMoviesDbContext context;
        public DirectorService(GeorgesMoviesDbContext context)
        {
            this.context = context;
        }
        public Director CreateDirector(string firstName, string lastName)
        {
            var diretor = new Director()
            {
                FirstName = firstName,
                LastName = lastName
            };

            return diretor;
        }
        public DirectorFullName GetMovieDirector(Movie currMovie)
        {
            return this.context.Directors
                .Where(d => d.Movies.Contains(currMovie))
                .Select(d => new DirectorFullName
                {
                    FullName = d.FirstName + " " + d.LastName
                })
                .FirstOrDefault();
        }


        public bool IsDirectorInMovie(string directorNames)
        {
            return this.context.Directors
                .Any(d => directorNames.Contains(d.FirstName) &&
                 directorNames.Contains(d.LastName));
        }
    }
}
