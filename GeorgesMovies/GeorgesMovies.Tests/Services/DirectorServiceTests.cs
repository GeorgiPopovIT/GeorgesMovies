using GeorgesMovies.Models.Models;
using GeorgesMovies.Services.Directors;
using GeorgesMovies.Services.Directors.DTO;
using GeorgesMovies.Tests.Mocks;
using System.Linq;
using Xunit;

namespace GeorgesMovies.Tests.Services
{
    public class DirectorServiceTests
    {
        [Fact]
        public void CreateDirectorSuccsessfully()
        {
            //Arrange
            var context = DatabaseMock.Instance;

            var directorService = new DirectorService(context);

            //Act
            var result = directorService.CreateDirector("Georgi", "Petrov");

            //Assert
            Assert.IsType<Director>(result);
            Assert.Equal(1, context.Directors.Count());
        }
        [Fact]
        public void TryToAddDirectorIfHeContainsInDatabase()
        {
            //Arrange
            var context = DatabaseMock.Instance;

            var directorService = new DirectorService(context);
            directorService.CreateDirector("Georgi", "Petrov");

            //Act
            directorService.CreateDirector("Georgi", "Petrov");

            //Assert
            Assert.Equal(1, context.Directors.Count());
        }

        [Fact]
        public void IsDirectorInMovie()
        {
            //Arrange
            var context = DatabaseMock.Instance;

            var directorService = new DirectorService(context);

            //Act
            directorService.CreateDirector("Georgi", "Petrov");

            var trueResult = directorService.IsDirectorInMovie("Georgi Petrov");
            var falseResult = directorService.IsDirectorInMovie("Georgi Qnkov");

            //Assert

            Assert.True(trueResult);
            Assert.False(falseResult);
        }

        [Fact]
        public void GetMovieDirectorSuccsessfully()
        {
            //Arrange
            var context = DatabaseMock.Instance;

            var directorService = new DirectorService(context);

            var director = directorService.CreateDirector("Qnko", "Qnkov");

            var movie = new Movie
            {
                Title = "dd",
                Time = "1h 30",
                ReleaseDate = System.DateTime.Now,
                Overview = "testtesttesttesttesttesttesttesttest",
                Review = "testtesttesttesttesttesttesttesttesttesttesttesttest",
                GenreId = 1,
                DirectorId = 1,
                MovieUrl = "https://www.w3schools.bg/wp-content/uploads/2016/12/HTTP-LONG-POLLING.jpg",
                PictureUrl = "https://www.w3schools.bg/wp-content/uploads/2016/12/HTTP-LONG-POLLING.jpg",
                Rating = 5.90m,
                Director = director
            };
            context.Movies.Add(movie);
            context.SaveChanges();

            //Act
            var result = directorService.GetMovieDirector(movie);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<DirectorFullName>(result);
            Assert.Equal("Qnko Qnkov", result.FullName);
        }
    }
}
