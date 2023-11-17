using DemoASP_AccessData.Models.FormModels;
using Microsoft.AspNetCore.Mvc;
using NetFlask.DAL.Repository;
using NetFlask.DAL.Repository.Entities;

namespace DemoASP_AccessData.Controllers
{
	public class MovieController : Controller
	{
		private readonly IRepository<MoviesEntity, int> _movieRepo;
        public MovieController(IRepository<MoviesEntity, int> movieRepo)
        {
            _movieRepo = movieRepo;
        }
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
				MoviesEntity movie = new MoviesEntity
				{
					Title = form.Title,
					Description = form.Description
				};
				_movieRepo.Insert(movie);
				//Enregistrer en DB
			}
			return View(form);

		}
	}
}
