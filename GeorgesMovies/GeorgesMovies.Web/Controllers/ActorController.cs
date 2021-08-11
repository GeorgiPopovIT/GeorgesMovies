using System.Linq;
using GeorgesMovies.Services.Actors;
using GeorgesMovies.Services.Actors.DTO;
using GeorgesMovies.Web.Models.Actors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static GeorgesMovies.Web.WebConstants;


namespace GeorgesMovies.Web.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService actors;

        public ActorController(IActorService actors)
        {
            this.actors = actors;
        }

        [Authorize(Roles = AdminRoleName)]
        public IActionResult Add()
        {
            return View(new AddActorServiceModel
            {
                Movies = this.actors.GetMoviesTitles()
            });
        }

        [Authorize(Roles = AdminRoleName)]
        [HttpPost]
        public IActionResult Add(AddActorServiceModel actorToAdd)
        {
            var isActorInData = this.actors.ExistActorInMovie(actorToAdd);

            if (isActorInData)
            {
                this.ModelState.AddModelError(nameof(actorToAdd.FirstName), "This actor is already in movie");
            }
            if (!ModelState.IsValid)
            {
                return View(new AddActorServiceModel
                {
                    Movies = this.actors.GetMoviesTitles()
                });
            }
            this.actors.Add(actorToAdd);

            return RedirectToAction("Manage", "Movie");
        }

        [Authorize]
        public IActionResult All()
        {
            var actors = new AllActorsViewModel
            {
                Actors = this.actors.GetAllActorsNames().ToList()
            };

            return View(actors);
        }

        [Authorize]
        public IActionResult Info(int id)
        {
            var infoForActor = this.actors.GetInfoAboutActor(id);

            return View(infoForActor);
        }
    }
}
