using GeorgesMovies.Data;
using GeorgesMovies.Models.Models;
using System.Linq;

namespace GeorgesMovies.Services
{
    public static class AddDefaultGenres
    {
        public static void SeedGenres(GeorgesMoviesDbContext data)
        {
            if (data.Genres.Any())
            {
                return;
            }

            data.Genres.AddRange(new[]
            {
                new Genre { Name = "Action" },
                new Genre { Name = "Comedy" },
                new Genre { Name = "Drama" },
                new Genre { Name = "Fantasy" },
                new Genre { Name = "Mystery" },
                new Genre { Name = "Horror" },
                new Genre { Name = "Romance" },
            });

            data.SaveChanges();
        }
    }
}
