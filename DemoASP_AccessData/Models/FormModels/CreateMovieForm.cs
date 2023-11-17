using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoASP_AccessData.Models.FormModels
{
	public class CreateMovieForm
	{
		[Required(ErrorMessage = "Le titre du film est obligatoire")]
		[DisplayName("Titre du film")]
        public string Title{ get; set; }
        //[Required]
        //public string Categorie { get; set; }
		public string PicturePath { get; set; }
		public DateTime ReleaseDate { get; set; }
		[Range(0.0, 10.0)]
		public double Rating { get; set; }
        public string Description { get; set; }
    }
}
