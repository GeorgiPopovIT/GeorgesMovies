using Microsoft.EntityFrameworkCore;

namespace GeorgesMovies.Models.Data
{
    public class GeorgesMovieDbContext : DbContext
    {
        public GeorgesMovieDbContext()
        {

        }
        public GeorgesMovieDbContext(DbContextOptions options)
            :base(options)
        {

        }


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
