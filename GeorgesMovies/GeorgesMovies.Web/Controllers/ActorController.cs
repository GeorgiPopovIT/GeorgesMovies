using System;
using System.Linq;
using GeorgesMovies.Services.Actors;
using GeorgesMovies.Services.Actors.DTO;
using GeorgesMovies.Web.Models.Actors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GeorgesMovies.Web.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService actors;
        public ActorController(IActorService actors)
        {
            this.actors = actors;
        }

        [Authorize]
        public IActionResult Add()
        {
            return View(new AddActorServiceModel
            {
                Movies = this.actors.GetMoviesTitles()
            });
        }
        [Authorize]
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
