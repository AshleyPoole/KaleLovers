using Microsoft.AspNet.Mvc;

namespace KaleLovers.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Branch out to us #Kale.";

			return View();
		}

		public IActionResult Error()
		{
			return View();
		}
	}
}
