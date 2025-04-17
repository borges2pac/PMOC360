using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Services;

namespace PMOC360.Web.Pages.Pmoc.Modelo.Itens
{
    public class IndexModel : PageModel
    {
		private readonly IPmocModeloItensService _pmocModeloItensService;
		private readonly IPmocModeloService _pmocModeloService;

		public IndexModel(IPmocModeloItensService pmocModeloItensService, IPmocModeloService pmocModeloService)
		{
			_pmocModeloItensService = pmocModeloItensService;
			_pmocModeloService = pmocModeloService;
		}

		[BindProperty]
		public IEnumerable<ModeloItensModel> Itens { get; private set; }

		public string Modelo { get; private set; }

		public string AlertMessage { get; private set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			try
			{
				var retorno = _pmocModeloItensService.GetAllForId((int)id, 2);
				var modelo = _pmocModeloService.GetForId((int)id, 2);

				Itens = retorno;
				Modelo = modelo.Nome;
			}
			catch
			{
				return NotFound();
			}

			return Page();
		}
	}
}
