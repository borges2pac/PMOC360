using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Services;
using PMOC360.Web.Models.Services.Interfaces;
using PMOC360.Web.Models.ViewModels;

namespace PMOC360.Web.Pages.Pmoc.Plano
{
    public class IndexModel : PageModel
    {
		private readonly IPmocPlanoService _planoService;
		private readonly IClienteService _clienteService;

		public IndexModel(IPmocPlanoService planoService, IClienteService clienteService)
		{
			_planoService = planoService;
			_clienteService = clienteService;
		}

		[BindProperty]
		public IEnumerable<PmocPlanoViewModel> Planos { get; private set; }

		public string AlertMessage { get; private set; }

		public void OnGet()
		{
			PmocPlanoViewModel model = new PmocPlanoViewModel();
			List<PmocPlanoViewModel> list = new List<PmocPlanoViewModel>();
			int empresaId = 2;

			var planos = _planoService.GetAll(empresaId);

			if(planos != null)
			{
				foreach (var plano in planos) 
				{
					model = new PmocPlanoViewModel() 
					{
						Nome = plano.Nome,
						ClienteNome = _clienteService.GetForId(plano.Id_Cliente, empresaId).Nome.ToString(),
						Status = plano.Ativo == 1 ? "Em Andamento" : "Finalizado",
						Referencia = plano.Periodo_Ini.ToString("MMMM/yyyy")
					};

					list.Add(model);
				}
			}

			Planos = list;
		}
	}
}
