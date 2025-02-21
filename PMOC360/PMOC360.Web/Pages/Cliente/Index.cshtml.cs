using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMOC360.Web.Controllers;
using PMOC360.Web.Services;
using PMOC360.Web.ViewModels;

namespace PMOC360.Web.Pages.Cliente
{
    public class IndexModel : PageModel
    {
		private readonly ClienteService _clienteService;

		public IndexModel(ClienteService clienteService)
		{
			_clienteService = clienteService;
		}

		[BindProperty]
		public IEnumerable<ClienteViewModel> Clientes { get; private set; }

		public string AlertMessage { get; private set; }

		public void OnGet()
		{
			var clientes = _clienteService.GetClientes();

			Clientes = clientes;
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
