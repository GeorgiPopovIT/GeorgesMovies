using System;
using GeorgesMovies.Data;
using GeorgesMovies.Models.Models;
using GeorgesMovies.Services.Actors;
using GeorgesMovies.Web.Models.Actors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GeorgesMovies.Web.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService actors;
        public ActorController(IActorService actors)
        {
            this.actors = actors;
        }

        public IActionResult Add()
        {
            return View(new AddActorServiceModel
            {
                Movies = this.actors.GetMoviesTitles()
            });
        }
        [HttpPost]
        public IActionResult Add(AddActorServiceModel actorToAdd)
        {
            try
            {
                this.actors.Add(actorToAdd);
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(nameof(actorToAdd.FirstName), e.Message);
            }

            if (!ModelState.IsValid)
            {
                return View(new AddActorServiceModel
                {
                    Movies = this.actors.GetMoviesTitles()
                });
            }

            return RedirectToAction("Manage", "Movie");
        }

        public IActionResult All()
        {
            var actors = new AllActorsViewModel
            {
                Actors = this.actors.GetAllActorsNames().ToList()
            };

            return View(actors);
        }

        public IActionResult Info(int id)
        {
            var infoForActor = this.actors.GetInfoAboutActor(id);

            return View(infoForActor);
        }
    }
}
