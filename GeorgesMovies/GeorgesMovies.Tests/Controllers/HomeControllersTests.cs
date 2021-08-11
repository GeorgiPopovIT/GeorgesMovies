using GeorgesMovies.Services.Home;
using GeorgesMovies.Services.Movies;
using GeorgesMovies.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using MyTested.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

using static GeorgesMovies.Web.WebConstants.Cache;


namespace GeorgesMovies.Tests.Controllers
{

    public class HomeControllersTests
    {
        [Fact]
        public void ErrorShouldReturnView()
        {
            //Arrange
            var homeController = new HomeController(null, null);

            //Act
            var result = homeController.Error();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void IndexActionShouldReturnView()
        {
            //var controller = new HomeController()
        }

    }
}
