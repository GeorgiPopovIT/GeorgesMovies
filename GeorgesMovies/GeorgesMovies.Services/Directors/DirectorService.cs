using System.Linq;
using GeorgesMovies.Data;
using GeorgesMovies.Models.Models;
using GeorgesMovies.Services.Directors.DTO;

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
            var director = this.context.Directors.FirstOrDefault(d => d.FirstName == firstName
            && d.LastName == lastName);

            if (director == null)
            {
                director = new Director()
                {
                    FirstName = firstName,
                    LastName = lastName
                };
                this.context.Directors.Add(director);
                this.context.SaveChanges();
            }


            return director;
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
