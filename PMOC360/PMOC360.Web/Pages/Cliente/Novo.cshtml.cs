using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMOC360.Web.Models.Services;
using PMOC360.Web.Models.ViewModels;

namespace PMOC360.Web.Pages.Cliente
{
	public class NovoModel : PageModel
    {
		private readonly IClienteService _clienteService;

		public NovoModel(IClienteService clienteService)
		{
			_clienteService = clienteService;
		}

		[BindProperty]
		public ClienteCadViewModel Cliente { get; set; }

		public string Mensagem { get; set; }

		public IActionResult OnGet()
		{
			return Page();
		}

		[HttpPost]
		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				var cliente = Cliente;

				//Chamar rotina para cadastrar o cliente
				//var retornoExecucao = _cliente.CadastrarCliente(cliente);

				//Mensagem = retornoExecucao;
				//tratar retorno
				//return RedirectToPage("/Cliente/Index");
			}

			return Page();
		}
	}
}
