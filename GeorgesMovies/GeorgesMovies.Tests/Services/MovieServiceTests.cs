using GeorgesMovies.Services.Movies;
using GeorgesMovies.Services.Movies.DTO;
using GeorgesMovies.Tests.Mocks;
using System.Linq;
using Xunit;

namespace GeorgesMovies.Tests.Services
{
    public class MovieServiceTests
    {
        [Fact]
        public void CreateMovieSucssesfully()
        {
            //Arrange
            var context = DatabaseMock.Instance;

            var movieService = new MovieService(context, null, null,
                DirectorServiceMock.Instance, null, null);

            var movieForm = new MovieServiceFormModel
            {
                Title = "dd",
                Time = "1h 30",
                ReleaseDate = System.DateTime.Now,
                Overview = "testtesttesttesttesttesttesttesttest",
                Review = "testtesttesttesttesttesttesttesttesttesttesttesttest",
                GenreId = 1,
                MovieUrl = "https://www.w3schools.bg/wp-content/uploads/2016/12/HTTP-LONG-POLLING.jpg",
                PictureUrl = "https://www.w3schools.bg/wp-content/uploads/2016/12/HTTP-LONG-POLLING.jpg",
                Rating = 5.90m,
                Director = "Qnko Qnkov"
            };

            //Act
             movieService.Add(movieForm);

            Assert.Equal(1, context.Movies.Count());
        }
    }
}
