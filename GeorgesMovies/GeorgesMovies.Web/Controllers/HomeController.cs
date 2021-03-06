using GeorgesMovies.Services.Home;
using GeorgesMovies.Services.Movies;
using GeorgesMovies.Web.Models;
using GeorgesMovies.Web.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;

using static GeorgesMovies.Web.WebConstants.Cache;

namespace GeorgesMovies.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService home;
        private readonly IMemoryCache memoryCache;

        public HomeController(IHomeService home, IMemoryCache memoryCache)
        {
            this.home = home;
            this.memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            var movies = this.memoryCache.Get<List<IndexMovieViewModel>>(LatestThreeMoviesCacheKey);

            if (movies == null)
            {
                movies = this.home.GetLastThreeMovies();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

                this.memoryCache.Set(LatestThreeMoviesCacheKey, movies,cacheOptions);
            }

            return View(new IndexViewModel
            {
                Movies = movies
            });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
