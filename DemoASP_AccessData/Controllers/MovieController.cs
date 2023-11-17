using DemoASP_AccessData.Models.FormModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoASP_AccessData.Controllers
{
	public class MovieController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult CreateMovie()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateMovie(CreateMovieForm form)
		{
			if(ModelState.IsValid) 
			{ 
				//Enregistrer en DB
			}
			return View(form);

		}
	}
}
