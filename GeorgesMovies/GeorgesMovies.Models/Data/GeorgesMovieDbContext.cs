using GeorgesMovies.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace GeorgesMovies.Models.Data
{
    public class GeorgesMovieDbContext : DbContext
    {
        public GeorgesMovieDbContext()
        {

        }
        public GeorgesMovieDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database = GeorgesMovies;Integrated Security = true;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        
    }
}
