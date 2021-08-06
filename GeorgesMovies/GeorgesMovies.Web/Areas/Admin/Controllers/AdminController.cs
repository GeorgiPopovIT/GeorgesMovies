using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GeorgesMovies.Web.Areas.Admin.Controllers
{
    [Area(AdminAreaConstants.AreaName)]
    [Authorize]
    public abstract class AdminController : Controller
    {
    }
}
