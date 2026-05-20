using GeorgesMovies.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using static System.Formats.Asn1.AsnWriter;

namespace GeorgesMovies.Tests
{
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>,
      IDisposable
    {
        private readonly IServiceScope _scope;
        protected readonly GeorgesMoviesDbContext DbContext;

        protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();

            DbContext = _scope.ServiceProvider
                .GetRequiredService<GeorgesMoviesDbContext>();
        }
        public void Dispose()
        {
            _scope?.Dispose();
            DbContext?.Dispose();
        }
    }
}
