using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using GeorgesMovies.Data;
using GeorgesMovies.Models.Models;
using GeorgesMovies.Services.Mapping;
using GeorgesMovies.Services.Comments.DTO;

namespace GeorgesMovies.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly GeorgesMoviesDbContext context;
        private readonly IMapper mapper;
        public CommentService(GeorgesMoviesDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = MapperCreator.InitializeMapper(mapper);
        }

        public void Create(string userId, CommentServiceModel model)
        {
            var comment = new Comment
            {
                CreatedOn = DateTime.UtcNow,
                Message = model.Message,
                UserId = userId,
                MovieId = model.MovieId
            };

            this.context.Comments.Add(comment);

            this.context.SaveChanges();
        }

        public DetailCommentViewModel All(int movieId)
        {
            var result = this.GetAllComments(movieId);

            return new DetailCommentViewModel
            {
                Comments = result
            };
        }

        public IEnumerable<AllCommentsViewModel> GetAllComments(int movieId)
        {
            return this.context.Comments
                .Where(c => c.Movie.Id == movieId)
                .ProjectTo<AllCommentsViewModel>(this.mapper.ConfigurationProvider)
                .ToList();
        }

        public void Delete(int id)
        {
            var comment = this.context.Comments
                .FirstOrDefault(c => c.Id == id);

            this.context.Comments.Remove(comment);

            this.context.SaveChanges();
        }

        public int GetMovieIdByCommentId(int id)
        {
            var comment = this.context.Comments
                .FirstOrDefault(c => c.Id == id);

            return comment.MovieId;
        }
    }
}
