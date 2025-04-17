using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Services;
using PMOC360.Web.Models.ViewModels;

namespace PMOC360.Web.Pages.Tecnico
{
    public class IndexModel : PageModel
    {
		private readonly ITecnicoService _tecnicoService;

		public IndexModel(ITecnicoService tecnicoService)
		{
			_tecnicoService = tecnicoService;
		}

		[BindProperty]
		public IEnumerable<TecnicoModel> Tecnicos { get; private set; }

		public string AlertMessage { get; private set; }

		public void OnGet()
		{
			var tecnicos = _tecnicoService.GetAll(2);

			Tecnicos = tecnicos;
		}
	}
}
