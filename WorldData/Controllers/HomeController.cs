using Microsoft.AspNetCore.Mvc;
using using WorldData.Models;

namespace WorldData.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
