using GeorgesMovies.Services.Home;
using GeorgesMovies.Services.Movies;
using GeorgesMovies.Tests.Mocks;
using System.Collections.Generic;
using Xunit;

namespace GeorgesMovies.Tests.Services
{
    public class HomeServiceTests
    {
        [Fact]
        public void GetLastThreemoviesShouldReturnList()
        {
            var homeService = new HomeService(DatabaseMock.Instance);

            var result = homeService.GetLastThreeMovies();

            Assert.Empty(result);
            Assert.IsType<List<IndexMovieViewModel>>(result);
        }
    }
}
