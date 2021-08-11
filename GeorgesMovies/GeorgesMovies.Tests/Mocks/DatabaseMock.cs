using GeorgesMovies.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace GeorgesMovies.Tests.Mocks
{
   public static class DatabaseMock
    {
        public static GeorgesMoviesDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<GeorgesMoviesDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new GeorgesMoviesDbContext(dbContextOptions);
            }
        }
    }
}
