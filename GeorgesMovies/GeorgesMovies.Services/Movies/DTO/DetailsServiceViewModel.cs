using System.Collections.Generic;
using GeorgesMovies.Services.Actors.DTO;
using GeorgesMovies.Services.Comments;

namespace GeorgesMovies.Services.Movies.DTO
{
    public class DetailsServiceViewModel
    {
        public int Id { get; set; }

        public string Time { get; set; }

        public string MovieUrl { get; set; }

        public string Title { get; set; }

        public string Review { get; set; }

        public int Year { get; set; }

        public IEnumerable<ActorFullNameServiceModel> ActorNames { get; set; }

        public CommentServiceModel Comment { get; set; }

        public DetailCommentViewModel AllComments { get; set; }

        public string DirectorName { get; set; }
    }
}