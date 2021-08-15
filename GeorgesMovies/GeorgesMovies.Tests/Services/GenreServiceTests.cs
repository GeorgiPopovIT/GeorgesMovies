using Xunit;
using GeorgesMovies.Services.Genres;
using GeorgesMovies.Tests.Mocks;
using GeorgesMovies.Models.Models;

namespace GeorgesMovies.Tests.Services
{
    public class GenreServiceTests
    {
        [Fact]
        public void GenreServiceShouldReturnListOfAllGenres()
        {
            //Arrange
            var genreService = new GenreService(DatabaseMock.Instance);

            DatabaseMock.Instance.Genres.AddRange(
                new Genre { Name = "Horror" },
                new Genre { Name="Comedy"}
                );

            //Act
            var result = genreService.GetGenres();
            //Assert
            Assert.NotNull(result);

        }
    }
}
