using GeorgesMovies.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace GeorgesMovies.Data
{
    public class GeorgesMoviesDbContext : DbContext
    {
        public GeorgesMoviesDbContext()
        {

        }
        public GeorgesMoviesDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

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
