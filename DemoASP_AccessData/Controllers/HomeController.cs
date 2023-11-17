using DemoASP_AccessData.Models;
using Microsoft.AspNetCore.Mvc;
using NetFlask.DAL.Repository.Entities;
using NetFlask.DAL.Repository;
using System.Diagnostics;

namespace DemoASP_AccessData.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IRepository<MoviesEntity, int> _Mrepo;
		private readonly IRepository<GenreEntity, int> _Grepo;

		public HomeController(ILogger<HomeController> logger, IRepository<MoviesEntity, int> Mrepo,
			IRepository<GenreEntity, int> Grepo)
		{
			_logger = logger;
			_Mrepo = Mrepo;
			_Grepo = Grepo;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Details()
		{
			MoviesEntity me = _Mrepo.Get(2);
			List<GenreEntity> lgenre = (_Grepo as GenreRepository).GetByMovie(1).ToList();
			
			HeaderMovie Frozen = new HeaderMovie()
			{
				Title = me.Title,
				Categorie = "Tout public",
				Description = me.Description,
				Directors = "Chris Buck,Jennifer Lee",
				Genre = string.Join(",", lgenre.Select(g => g.Libelle)),
				PicturePath = me.PicturePath,
				Rating = me.Rating,
				ReleaseDate = me.ReleaseDate
			};
			

			return View(Frozen);
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
