using GeorgesMovies.Data;
using GeorgesMovies.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Testcontainers.MsSql;
using Xunit;

namespace GeorgesMovies.Tests
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>,
      IAsyncLifetime
    {
        private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
       .WithImage("mcr.microsoft.com/mssql/server:2019-latest")
       .WithPassword("yourStrong(!)Password")
       .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var descriptorType =
                typeof(DbContextOptions<GeorgesMoviesDbContext>);

                var descriptor = services
                    .SingleOrDefault(s => s.ServiceType == descriptorType);

                if (descriptor is not null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<GeorgesMoviesDbContext>(options =>
                    options.UseSqlServer(_dbContainer.GetConnectionString()));
            });
        }

        public Task DisposeAsync()
            => _dbContainer.StopAsync();

        public Task InitializeAsync()
            => _dbContainer.StartAsync();
    }
}
