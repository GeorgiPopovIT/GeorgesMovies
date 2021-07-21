using GeorgesMovies.Data;
using GeorgesMovies.Models.Models;
using GeorgesMovies.Web.Models.Actors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GeorgesMovies.Web.Controllers
{
    public class ActorController : Controller
    {
        private readonly GeorgesMoviesDbContext context;
        public ActorController(GeorgesMoviesDbContext context)
        {
            this.context = context;
        }

        public IActionResult Add()
        {
            return View(new AddActorInputModel
            {
                Movies = GetMoviesTitles()
            });
        }
        [HttpPost]
        public IActionResult Add(AddActorInputModel actorToAdd)
        {
            var movieToAdd = this.context.Movies
                .FirstOrDefault(m => m.Id == actorToAdd.MovieId);

            var actor = new Actor
            {
                FirstName = actorToAdd.FirstName,
                LastName = actorToAdd.LastName,
                Information = actorToAdd.Information
            };

            if (movieToAdd.Actors.Contains(actor))
            {
                this.ModelState.AddModelError(nameof(actor.FirstName),"This actor is already added to movie.");
            }

            if (!ModelState.IsValid)
            {
                actorToAdd.Movies = GetMoviesTitles();

                return View(actorToAdd);
            }
            movieToAdd.Actors.Add(actor);

            this.context.SaveChanges();

            return RedirectToAction(nameof(MovieController.Manage),nameof(MovieController));
        }

        public IActionResult All()
        {
            return View();
        }
        public IEnumerable<ActorsNamesViewModel> GetAllActorsNames()
        {
            var actors = this.context.Actors
                .Select(a => new ActorsNamesViewModel
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName
                })
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToList();

            return actors;
        }
        public IEnumerable<ActorMovieViewModel> GetMoviesTitles()
        {
            return this.context.Movies
                .Select(m => new ActorMovieViewModel
                {
                    Id = m.Id,
                    Title = m.Title
                })
                .ToList();

        } 
    }
}
