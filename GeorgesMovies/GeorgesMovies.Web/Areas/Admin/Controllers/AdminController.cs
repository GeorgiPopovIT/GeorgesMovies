using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static GeorgesMovies.Web.WebConstants;


namespace GeorgesMovies.Web.Areas.Admin.Controllers
{
    [Area(AdminAreaConstants.AreaName)]
    [Authorize(Roles = AdminRoleName)]
    public abstract class AdminController : Controller
    {
    }
}
