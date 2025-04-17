using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMOC360.Web.Models.Services;
using PMOC360.Web.Models.ViewModels;
using System.Linq;

namespace PMOC360.Web.Pages.Cliente
{
	public class IndexModel : PageModel
    {
		private readonly IClienteService _clienteService;

		public IndexModel(IClienteService clienteService)
		{
			_clienteService = clienteService;
		}

		[BindProperty]
		public IEnumerable<ClienteViewModel> Clientes { get; private set; }

		public int PaginaAtual { get; set; }

		public int TotalPaginas { get; set; }

		public string AlertMessage { get; private set; }

		public void OnGet(int pagina = 1)
		{
			int tamanhoPagina = 5;
			int totalItens = 0;

			var clientes = _clienteService.GetAll(2);

			totalItens = clientes.Count();
			TotalPaginas = (int)Math.Ceiling(totalItens / (double)tamanhoPagina);
			PaginaAtual = pagina;

			Clientes = clientes
				.Skip((pagina - 1) * tamanhoPagina)
				.Take(tamanhoPagina)
				.ToList();

			//Clientes = clientes;
		}

		//public async Task<IActionResult> OnGetDeleteAsync(int id)
		//{
		//	var item = id;

		//	if (id > 0 || id != null)
		//	{
		//		var retorno = _cliente.DesativarCliente(id);
		//		TempData["AlertMessage"] = retorno.ToString();
		//	}

		//	return RedirectToPage();
		//}
	}
}
