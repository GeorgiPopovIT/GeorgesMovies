using GeorgesMovies.Data;
using GeorgesMovies.Services.Genres.DTO;
using System.Collections.Generic;
using System.Linq;

namespace GeorgesMovies.Services.Genres
{
    public class GenreService : IGenreService
    {
        private readonly GeorgesMoviesDbContext context;

        public GenreService(GeorgesMoviesDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<GenreServiceFormModel> GetGenres()
        {
            return this.context
                .Genres
                .Select(g => new GenreServiceFormModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToList();
        }
    }
}
