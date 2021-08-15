using GeorgesMovies.Data;
using GeorgesMovies.Models.Models;
using GeorgesMovies.Services.Actors;
using GeorgesMovies.Services.Actors.DTO;
using GeorgesMovies.Tests.Mocks;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GeorgesMovies.Tests.Services
{
    public class ActorServiceTests
    {
        private GeorgesMoviesDbContext globalContext = DatabaseMock.Instance;

        [Fact]
        public void IsActorAddedSuccwssfully()
        {
            //Arrange
            var actorService = new ActorService(globalContext, MapperMock.Instance);

            var model = new AddActorServiceModel()
            {
                FirstName = "Ivan",
                MovieId = 1
            };
            globalContext.Movies.Add(new Movie { Id = 1, Title = "One" });

            this.globalContext.SaveChanges();
            //Act
            actorService.Add(model);

            //Assert
            Assert.Equal(1, globalContext.Actors.Count());
        }

        [Fact]
        public void GetAllActorNamesSuccesfully()
        {
            //Arrange
            var actorService = new ActorService(globalContext, MapperMock.Instance);

            this.globalContext.Actors.AddRange(new[]
            {
                new Actor(){FirstName = "Qnko" },
                new Actor(){ FirstName = "Misho"}
            });

            this.globalContext.SaveChanges();

            //Act

            var actualResult = actorService.GetAllActorsNames();

            //Assert
            Assert.NotNull(actualResult);
            Assert.Equal(2, actualResult.Count());
            Assert.IsAssignableFrom<IEnumerable<ActorFullNameServiceModel>>(actualResult);
        }

        [Fact]
        public void ActorInformationMethodShouldWorkCorrectly()
        {
            //Arrange
            var actorService = new ActorService(globalContext, MapperMock.Instance);

            this.globalContext.Actors.Add(new Actor { Id = 1, FirstName = "Qnko" });

            this.globalContext.SaveChanges();

            //Act
            var actualResult = actorService.GetInfoAboutActor(1);

            //Assert
            Assert.NotNull(actualResult);
            Assert.Equal("Qnko", actualResult.FirstName);
        }

        [Fact]
        public void GetMoviesTitlesMethodShouldWorkCorrectly()
        {
            //Arrange
            var actorService = new ActorService(globalContext, MapperMock.Instance);

            this.globalContext.Actors.Add(new Actor { Id = 1, FirstName = "Qnko" });

            this.globalContext.SaveChanges();

            //Act
            var result = actorService.GetMoviesTitles();

            //Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<ActorMovieServiceModel>>(result);
        }

        [Fact]
        public void IsExistActorInMovieMethodShouldReturnTrue()
        {
            //Arrange
            var actorService = new ActorService(globalContext, MapperMock.Instance);

            var actorToAdd = new Actor
            {
                FirstName = "Qnko",
                LastName = "Qnkov"
            };
            this.globalContext.Actors.Add(actorToAdd);

            var movieToAdd = new Movie
            {
                Id = 1,
                Title = "One"
            };

            movieToAdd.Actors.Add(actorToAdd);

            this.globalContext.Movies.Add(movieToAdd);

            var model = new AddActorServiceModel
            {
                FirstName = "Qnko",
                LastName = "Qnkov",
                MovieId = 1
            };

            this.globalContext.SaveChanges();

            //Act

            var actualResult = actorService.ExistActorInMovie(model);

            //Assert
            Assert.True(actualResult);
        }

        [Fact]
        public void IsExistActorMethodShouldReturnFalseIfActorIsNull()
        {
            //Arrange
            var actorService = new ActorService(globalContext, MapperMock.Instance);

            var actorToAdd = new Actor
            {
                FirstName = "Qnko",
                LastName = "Petrov"
            };
            this.globalContext.Actors.Add(actorToAdd);

            var movieToAdd = new Movie
            {
                Id = 1,
                Title = "One"
            };

            movieToAdd.Actors.Add(actorToAdd);

            this.globalContext.Movies.Add(movieToAdd);

            var model = new AddActorServiceModel
            {
                FirstName = "Qnko",
                LastName = "Qnkov",
                MovieId = 1
            };

            this.globalContext.SaveChanges();

            //Act

            var actualResult = actorService.ExistActorInMovie(model);

            //Assert
            Assert.False(actualResult);
        }

        [Fact]
        public void IsExistActorMethodShouldReturnFalseIfActorIsNotInMovie()
        {
            //Arrange
            var actorService = new ActorService(globalContext, MapperMock.Instance);

            var actorToAdd = new Actor
            {
                FirstName = "Qnko",
                LastName = "Qnkov"
            };
            this.globalContext.Actors.Add(actorToAdd);

            var movieToAdd = new Movie
            {
                Id = 1,
                Title = "One"
            };


            this.globalContext.Movies.Add(movieToAdd);

            var model = new AddActorServiceModel
            {
                FirstName = "Qnko",
                LastName = "Qnkov",
                MovieId = 1
            };

            this.globalContext.SaveChanges();

            //Act

            var actualResult = actorService.ExistActorInMovie(model);

            //Assert
            Assert.False(actualResult);
        }

        [Fact]
        public void GetActorsInCurrentMovieShouldWorkCorrect()
        {
            //Arrange
            var actorService = new ActorService(globalContext, MapperMock.Instance);

            var actorsToAdd = new List<Actor>
            {
                new Actor(){FirstName = "Qnko",LastName="Qnkov" },
                new Actor(){FirstName = "Gosho",LastName="Goshov"}
            };
            this.globalContext.Actors.AddRange(actorsToAdd);

            var movieModel = new Movie
            {
                Id = 1,
                Title = "oe"
            };
            movieModel.Actors.Add(actorsToAdd[0]);
            movieModel.Actors.Add(actorsToAdd[1]);

            this.globalContext.Movies.Add(movieModel);

            this.globalContext.SaveChanges();

            //Act

            var result = actorService.GetActorsInCurrentMovie(movieModel);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
    }
}
