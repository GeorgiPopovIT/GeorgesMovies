using AutoMapper;
using GeorgesMovies.Models.Models;
using GeorgesMovies.Services.Actors.DTO;
using GeorgesMovies.Services.Comments;
using GeorgesMovies.Services.Movies.DTO;

namespace GeorgesMovies.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Movies
            this.CreateMap<MovieServiceFormModel, Movie>()
                .ReverseMap();

            this.CreateMap<Movie, DetailsServiceViewModel>()
                .ForMember(dm => dm.Year, cfg => cfg.MapFrom(m => m.ReleaseDate.Year));

            this.CreateMap<Movie, AllMovieServiceModel>();

            this.CreateMap<Movie, ManageServiceViewModel>()
                .ForMember(mm => mm.Genre, cfg => cfg.MapFrom(m => m.Genre.Name));

            //Actors
            this.CreateMap<AddActorServiceModel, Actor>()
                .ReverseMap();

            this.CreateMap<Actor, ActorFullNameServiceModel>().ReverseMap();

            this.CreateMap<Actor, ActorInformationServiceModel>();

            this.CreateMap<Movie, ActorMovieServiceModel>();

            //Comments
            this.CreateMap<Comment, AllCommentsViewModel>()
                .ForMember(c => c.UserFullName,cfg => cfg.MapFrom(a => a.User.UserName));
        }
    }
}
