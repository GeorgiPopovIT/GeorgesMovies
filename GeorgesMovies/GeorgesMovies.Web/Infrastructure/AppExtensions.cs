using System;
using GeorgesMovies.Data;
using GeorgesMovies.Models.Models;
using GeorgesMovies.Services.Genres;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using static GeorgesMovies.Web.WebConstants;

namespace GeorgesMovies.Web.Infrastructure
{

    public static class AppExtensions
    {
        private const string adminEmail = "admin1@mail.com";
        private const string adminPassword = "gogo1912";
        private const string adminUsername = "gogo";

        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var servicedProvider = scopedServices.ServiceProvider;

            var data = scopedServices.ServiceProvider.GetService<GeorgesMoviesDbContext>();


            AddDefaultGenres.SeedGenres(data);

            SeedAdministrator(data, servicedProvider);

            return app;
        }

        private static void SeedAdministrator(GeorgesMoviesDbContext context, IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    return;
                }
                var role = new IdentityRole { Name = AdminRoleName };

                await roleManager.CreateAsync(role);

                var user = new User
                {
                    Email = adminEmail,
                    UserName = adminUsername,
                    FullName = "    "
                };

                await userManager.CreateAsync(user,adminPassword);

                await userManager.AddToRoleAsync(user, role.Name);


            })
                .GetAwaiter()
                .GetResult();
        }
    }
}
