using Microsoft.AspNetCore.Mvc;

namespace WritersClub.Controllers
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