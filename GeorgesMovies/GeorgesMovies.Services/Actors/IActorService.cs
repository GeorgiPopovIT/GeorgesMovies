using GeorgesMovies.Models.Models;
using GeorgesMovies.Services.Actors.DTO;
using System.Collections.Generic;

namespace GeorgesMovies.Services.Actors
{
    public interface IActorService
    {
        void Add(AddActorServiceModel model);

        ActorInformationServiceModel GetInfoAboutActor(int id);

        IEnumerable<ActorFullNameServiceModel> GetAllActorsNames();

        IEnumerable<ActorMovieServiceModel> GetMoviesTitles();

        bool ExistActorInMovie(AddActorServiceModel actorModel);

        IEnumerable<ActorFullNameServiceModel> GetActorsInCurrentMovie(Movie currMovie);
    }
}
