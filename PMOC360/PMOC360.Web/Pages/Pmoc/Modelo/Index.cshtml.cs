using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Services;
using PMOC360.Web.Models.ViewModels;

namespace PMOC360.Web.Pages.Pmoc.Modelo
{
    public class IndexModel : PageModel
    {
		private readonly IPmocModeloService _pmocModeloService;

		public IndexModel(IPmocModeloService pmocModeloService)
		{
			_pmocModeloService = pmocModeloService;
		}

		[BindProperty]
		public IEnumerable<PmocModeloModel> Modelos { get; private set; }

		public string AlertMessage { get; private set; }

		public void OnGet()
		{
			var modelos = _pmocModeloService.GetAll(2);

			Modelos = modelos;
		}
	}
}
