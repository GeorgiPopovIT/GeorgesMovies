using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GeorgesMovies.Data;
using GeorgesMovies.Models.Models;
using GeorgesMovies.Services.Actors.DTO;
using GeorgesMovies.Services.Mapping;


namespace GeorgesMovies.Services.Actors
{
    public class ActorServcie : IActorService
    {
        private readonly GeorgesMoviesDbContext context;
        private readonly IMapper mapper;

        public ActorServcie(GeorgesMoviesDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = MapperCreator.InitializeMapper(mapper);
        }

        public void Add(AddActorServiceModel actorModel)
        {
            var movieToAdd = this.context.Movies
                .FirstOrDefault(m => m.Id == actorModel.MovieId);

            var actorToAdd = this.mapper.Map<Actor>(actorModel);


            this.context.Actors.Add(actorToAdd);
            actorToAdd.Movies.Add(movieToAdd);


            this.context.SaveChanges();
        }

        public IEnumerable<ActorFullNameServiceModel> GetAllActorsNames()
        {
            var actors = this.context.Actors
              .ProjectTo<ActorFullNameServiceModel>(this.mapper.ConfigurationProvider)
              .OrderBy(a => a.FirstName)
              .ThenBy(a => a.LastName)
              .ToList();

            return actors;
        }

        public ActorInformationServiceModel GetInfoAboutActor(int id)
        {
            return this.context.Actors
                .ProjectTo<ActorInformationServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<ActorMovieServiceModel> GetMoviesTitles()
        {
            return this.context.Movies
              .ProjectTo<ActorMovieServiceModel>(this.mapper.ConfigurationProvider)
              .ToList();
        }

        public IEnumerable<ActorFullNameServiceModel> GetActorsInCurrentMovie(Movie currMovie)
        {
            return this.context.Actors.Where(a => a.Movies.Contains(currMovie))
                .ProjectTo<ActorFullNameServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();
        }

        public bool ExistActorInMovie(AddActorServiceModel actorModel)
        {
            var actor = this.context.Actors
                .Where(a => a.FirstName == actorModel.FirstName
            && a.LastName == actorModel.LastName)
                .FirstOrDefault();
            if (actor == null)
            {
                return false;
            }

            if (actor.Movies.Any(a => a.Id == actorModel.MovieId))
            {
                return true;
            }
            return false;
        }
    }
}
