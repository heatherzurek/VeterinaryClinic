using Microsoft.AspNetCore.Mvc;

namespace BHVet.Controllers
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
