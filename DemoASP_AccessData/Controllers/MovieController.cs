using DemoASP_AccessData.Models;
using DemoASP_AccessData.Models.FormModels;
using Microsoft.AspNetCore.Mvc;
using NetFlask.DAL.Repository;
using NetFlask.DAL.Repository.Entities;

namespace DemoASP_AccessData.Controllers
{
	public class MovieController : Controller
	{
		private readonly IRepository<MoviesEntity, int> _movieRepo;
		
		private readonly IRepository<GenreEntity, int> _genreRepo;
        public MovieController(IRepository<MoviesEntity, int> movieRepo, IRepository<GenreEntity, int> genreRepo)
        {
            _movieRepo = movieRepo;
			_genreRepo = genreRepo;
        }
        public IActionResult Index()
		{
			return View(_movieRepo.GetAll());
		}

		public IActionResult Details(int id)
		{
			MoviesEntity me = _movieRepo.Get(id);
            List<GenreEntity> lgenre = (_genreRepo as GenreRepository).GetByMovie(1).ToList();

            HeaderMovie movie = new HeaderMovie()
            {
                Title = me.Title,
                Categorie = "Tout public",
                Description = me.Description,
                Directors = "Pas encore implémenté",
                Genre = string.Join(",", lgenre.Select(g => g.Libelle)),
                PicturePath = me.PicturePath,
                Rating = me.Rating,
                ReleaseDate = me.ReleaseDate
            };
			return View(movie);
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
					Description = form.Description,
					ReleaseDate = form.ReleaseDate,
					Rating = form.Rating,
					PicturePath = form.PicturePath
				};
				_movieRepo.Insert(movie);
				//Enregistrer en DB
			}
			return View(form);

		}
	}
}
