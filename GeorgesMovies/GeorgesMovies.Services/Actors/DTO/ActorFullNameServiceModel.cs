using System.Collections.Generic;

namespace GeorgesMovies.Services.Actors.DTO
{
    public class ActorFullNameServiceModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<ActorInformationServiceModel> ActorsInfo{ get; set; }
    }
}
