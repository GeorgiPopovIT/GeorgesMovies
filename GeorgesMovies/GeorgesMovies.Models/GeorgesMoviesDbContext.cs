using GeorgesMovies.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GeorgesMovies.Data
{
    public class GeorgesMoviesDbContext : IdentityDbContext<User>
    {
        public GeorgesMoviesDbContext()
        {

        }
        public GeorgesMoviesDbContext(DbContextOptions<GeorgesMoviesDbContext> options)
            : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Comment> Comments { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=.;Database = GeorgesMovies;Integrated Security = true;");
        //        optionsBuilder.UseSqlServer("Data Source=SQL5107.site4now.net;Initial Catalog=db_a842fc_georges1912;User Id=db_a842fc_georges1912_admin;Password=aleksneikov1");
        //    }
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>()
                .HasMany(a => a.Actors)
                .WithMany(m => m.Movies)
                .UsingEntity<Dictionary<string, object>>(
                "MoviesActors",
                f => f.HasOne<Actor>().WithMany().OnDelete(DeleteBehavior.Restrict),
                 f => f.HasOne<Movie>().WithMany().OnDelete(DeleteBehavior.Restrict)
                );

            builder.Entity<Comment>()
                .HasOne(u => u.User)
                .WithMany(c => c.Comments)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
               .HasOne(m => m.Movie)
               .WithMany(c => c.Comments)
               .OnDelete(DeleteBehavior.Restrict);

            
            builder.Entity<Movie>()
              .HasOne(m => m.Director)
              .WithMany(c => c.Movies)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Movie>()
              .HasOne(m => m.Genre)
              .WithMany(c => c.Movies)
              .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
