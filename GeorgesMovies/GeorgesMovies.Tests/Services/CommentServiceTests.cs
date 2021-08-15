using Xunit;
using System.Linq;
using GeorgesMovies.Data;
using GeorgesMovies.Services.Comments;
using GeorgesMovies.Tests.Mocks;
using GeorgesMovies.Services.Comments.DTO;
using System.Collections.Generic;
using GeorgesMovies.Models.Models;

namespace GeorgesMovies.Tests.Services
{
    public class CommentServiceTests
    {
        private GeorgesMoviesDbContext globalContext = DatabaseMock.Instance;

        [Fact]
        public void CreateCommentMethodShouldWorkOk()
        {
            //Arrange
            var commentService = new CommentService(globalContext, MapperMock.Instance);

            var commentModel = new CommentServiceModel
            {
                Message = "HELLOOOOOOOOO",
                MovieId = 1
            };
            //Act

            commentService.Create("test", commentModel);

            //Assert
            Assert.Equal(1, globalContext.Comments.Count());
        }

        [Fact]
        public void TestGetAllCommentsMethod()
        {
            //Arrange
            var commentService = new CommentService(globalContext,
                MapperMock.Instance);

            this.globalContext.Comments.Add(new Comment { Message = "dd", MovieId = 1 });

            this.globalContext.SaveChanges();

            //Act

            var actualResult = commentService.GetAllComments(1);

            //Assert
            Assert.NotNull(actualResult);
            Assert.IsAssignableFrom<IEnumerable<AllCommentsViewModel>>(actualResult);
        }

        [Fact]
        public void DeleteMethodTest()
        {
            var commentService = new CommentService(globalContext,
               MapperMock.Instance);

            this.globalContext.Comments.Add(new Comment { Id = 1, Message = "dd", MovieId = 1 });

            this.globalContext.SaveChanges();

            //Act
            commentService.Delete(1);

            //Assert
            Assert.Equal(0, this.globalContext.Comments.Count());
        }

        [Fact]
        public void TestGetMovieIdByCommentIdMethodSusscess()
        {
            //Arrange
            var commentService = new CommentService(globalContext,
               MapperMock.Instance);

            this.globalContext.Comments.Add(new Comment { Id = 1, Message = "dd", MovieId = 1 });

            this.globalContext.SaveChanges();

            //Act
            var result = commentService.GetMovieIdByCommentId(1);

            //Assert
            Assert.Equal(1, result);
        }
    }
}
