using GeorgesMovies.Data;
using GeorgesMovies.Services.Genres;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GeorgesMovies.Web.Infrastructure
{
    public static class AppExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<GeorgesMoviesDbContext>();


            AddDefaultGenres.SeedGenres(data);

            return app;
        }
    }
}
