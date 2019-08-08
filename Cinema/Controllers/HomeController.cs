using Microsoft.AspNetCore.Mvc;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class HomeController : Controllers
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}