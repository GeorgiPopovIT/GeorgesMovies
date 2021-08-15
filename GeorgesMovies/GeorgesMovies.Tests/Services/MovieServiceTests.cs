using Xunit;
using System.Linq;
using GeorgesMovies.Services.Movies;
using GeorgesMovies.Services.Movies.DTO;
using GeorgesMovies.Tests.Mocks;
using GeorgesMovies.Models.Models;
using System.Collections.Generic;
using GeorgesMovies.Data;
using GeorgesMovies.Services.Directors;
using Moq;
using GeorgesMovies.Services.Genres;
using GeorgesMovies.Services.Actors;
using GeorgesMovies.Services.Comments;

namespace GeorgesMovies.Tests.Services
{
    public class MovieServiceTests
    {
        private GeorgesMoviesDbContext globalContext = DatabaseMock.Instance;


        [Fact]
        public void CreateMovieSucssesfully()
        {
            //Arrange

            var movieService = new MovieService(globalContext, null, null,
                DirectorServiceMock.Instance, null, null);

            var movieForm = new MovieServiceFormModel
            {
                Title = null,
                Director = "Qnko Qnkov"
            };

            //Act
            movieService.Add(movieForm);

            //Assert
            Assert.Equal(1, globalContext.Movies.Count());
        }

        [Theory]
        [InlineData("qnko", "gosho")]
        public void IsThisMovieExistTestMethod(string trueName, string falseName)
        {
            //Arrange

            var movieService = new MovieService(globalContext, null, null,
                null, null, null);


            globalContext.Movies.Add(new Movie { Title = "qnko" });

            globalContext.SaveChanges();
            //Act
            var result = movieService.IsMovieExist(new MovieServiceFormModel { Title = trueName });

            var falseResult = movieService.IsMovieExist(new MovieServiceFormModel { Title = falseName });

            //Assert
            Assert.True(result);
            Assert.False(falseResult);
        }

        [Fact]
        public void TestManageMethodShouldReturnManageServiceViewModel()
        {
            //Arrange
            var movieService = new MovieService(globalContext, MapperMock.Instance,
                null, null, null, null);

            globalContext.Movies.Add(new Movie { Title = "One" });

            //Act

            var result = movieService.Manage();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ManageServiceViewModel>(result);
        }

        [Fact]
        public void TestManageListingMethodShouldReturnList()
        {
            //Arrange

            var movieService = new MovieService(globalContext, MapperMock.Instance,
                null, null, null, null);

            globalContext.Movies.Add(new Movie { Title = "One" });

            //Act
            var result = movieService.ManageListing();


            //Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<ManageServiceViewModel>>(result);

        }

        [Fact]
        public void GetMovieByIdMethodShouldReturnMovieServiceFormModelSuccessfully()
        {
            //Arrange

            var movieService = new MovieService(globalContext, MapperMock.Instance,
                null, null, null, null);

            globalContext.Directors.Add(new Director
            { Id = 1, FirstName = "Qnko", LastName = "Qnkov" });

            globalContext.Movies.Add(new Movie { Id = 1, Title = "One", DirectorId = 1 });

            globalContext.SaveChanges();
            //Act
            var result = movieService.GetMovieById(1);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("One", result.Title);

        }

        [Fact]
        public void DeleteMethodShouldWorkCorrectly()
        {
            //Arrange
            var movieService = new MovieService(globalContext, MapperMock.Instance,
                null, null, null, null);

            this.globalContext.Movies.Add(new Movie { Id = 1, Title = "One" });

            this.globalContext.SaveChanges();

            //Act
            movieService.Delete(1);


            //Assert
            Assert.Equal(0, this.globalContext.Movies.Count());
        }

        [Fact]
        public void GetMovieListingShouldWorkCorrect()
        {
            //Arrange
            var movieService = new MovieService(globalContext, MapperMock.Instance,
                null, null, null, null);

            var movies = new List<Movie>()
            {
                new Movie{ Id = 1,Title = "First"},
                new Movie{ Id = 2,Title="Second"}
            };

            this.globalContext.AddRange(movies);

            this.globalContext.SaveChanges();
            //Act
            var result = movieService.GetMoviesListing();

            //Assert
            Assert.IsAssignableFrom<IQueryable<AllMovieServiceModel>>(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void EditMovieMethodShouldWorkCorrectly()
        {
            //Arrange
            var mock = new Mock<DirectorService>(globalContext);

            var movieService = new MovieService(globalContext, MapperMock.Instance,
                null, mock.Object, null, null);

            var movieModel = new MovieServiceFormModel
            {
                Title = "Change",
                Director = "Qnko Qnkov"
            };

            this.globalContext.Directors.Add(new Director { Id = 1, FirstName = "Qnko", LastName = "Qnkov" });

            this.globalContext.Movies.Add(new Movie
            {
                Id = 1,
                Title = "First",
                Time = "1",
                DirectorId = 1
            });

            this.globalContext.SaveChanges();
            //Act
            var actualResult = movieService.Edit(1, movieModel);

            //Assert
            Assert.True(actualResult);
        }

        [Fact]
        public void EditMovieMethodShouldReturnFalse()
        {
            //Arrange
            var mock = new Mock<DirectorService>(globalContext);

            var movieService = new MovieService(globalContext, MapperMock.Instance,
                null, mock.Object, null, null);

            this.globalContext.Movies.Add(new Movie
            {
                Id = 1,
                Title = "First",
                Time = "1",
                DirectorId = 1
            });

            this.globalContext.SaveChanges();

            var movieModel = new MovieServiceFormModel
            {
                Title = "Change",
                Director = "Qnko Qnkov"
            };

            //Act
            var actualResult = movieService.Edit(2, movieModel);

            //Assert
            Assert.False(actualResult);
        }

        [Fact]
        public void EditMovieMethodWithDiffrentDirector()
        {
            //Arrange
            var mock = new Mock<DirectorService>(globalContext);

            var movieService = new MovieService(globalContext, MapperMock.Instance,
                null, mock.Object, null, null);

            var movieModel = new MovieServiceFormModel
            {
                Title = "Change",
                Director = "Petar Petrov"
            };

            this.globalContext.Directors.Add(new Director { Id = 1, FirstName = "Qnko", LastName = "Qnkov" });

            this.globalContext.Movies.Add(new Movie
            {
                Id = 1,
                Title = "First",
                Time = "1",
                DirectorId = 1
            });

            this.globalContext.SaveChanges();

            //Act
            var actualResult = movieService.Edit(1, movieModel);

            //Assert
            Assert.True(actualResult);
        }

        [Fact]
        public void AllMethodShouldRetrunMoviesQueryServiceModel()
        {
            var mockGenre = new Mock<GenreService>(globalContext);
            //Arrange
            var movieService = new MovieService(globalContext, MapperMock.Instance,
                null, null, mockGenre.Object, null);

            this.globalContext.Genres.Add(new Genre { Id = 1, Name = "Action" });


            this.globalContext.Movies.Add(new Movie
            {
                Title = "One",
                Overview = "testtesttest",
                GenreId = 1
            });
            this.globalContext.Movies.Add(new Movie
            {
                Title = "Second",
                Overview = "testtesttest",
                GenreId = 1
            });

            this.globalContext.SaveChanges();

            //Act

            var actualResult = movieService.All(" ", 1, 1, 1);

            //Assert
            Assert.NotNull(actualResult);
            Assert.Equal(1, actualResult.MoviesPerPage);
            Assert.Equal(1, actualResult.CurrentPage);
        }

        [Fact]
        public void TestDetailsMethod()
        {
            var mockActors = new Mock<ActorService>(globalContext, MapperMock.Instance);
            var mockDirectors = new Mock<DirectorService>(globalContext);
            var commentMock = new Mock<CommentService>(globalContext, MapperMock.Instance);
            //Arrange
            var movieService = new MovieService(globalContext, MapperMock.Instance,
                mockActors.Object, mockDirectors.Object, null, commentMock.Object);

            var movieToAdd = new Movie { Id = 1, Title = "One" };
            this.globalContext.Movies.Add(movieToAdd);

            var actor1 = new Actor() { FirstName = "Qnko", LastName = "Qnkov" };
            var actor2 = new Actor() { FirstName = "Petar", LastName = "Petrov" };
            actor1.Movies.Add(movieToAdd);
            actor2.Movies.Add(movieToAdd);

            this.globalContext.Actors.AddRange(new List<Actor>()
            {
                actor1,
                actor2
            });
            var directorToAdd = new Director
            {
                FirstName = "Qnko",
                LastName = "Qnkov"
            };
            directorToAdd.Movies.Add(movieToAdd);
            this.globalContext
                .Directors.Add(directorToAdd);

            this.globalContext.Comments.Add(new Comment { Message = "dasdadadd", MovieId = 1 });

            this.globalContext.SaveChanges();

            //Act
            var actualResult = movieService.Details(1);

            //Assert
            Assert.NotNull(actualResult);
            Assert.IsType<DetailsServiceViewModel>(actualResult);
        }
    }
}
