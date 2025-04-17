using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMOC360.Web.Models.Services;
using PMOC360.Web.Models.ViewModels;

namespace PMOC360.Web.Pages.Cliente
{
	public class EditarModel : PageModel
    {
		private readonly IClienteService _clienteService;

		public EditarModel(IClienteService clienteService)
		{
			_clienteService = clienteService;
		}

		[BindProperty]
		public ClienteViewModel Cliente { get; set; }

		public string Mensagem { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			var retorno = _clienteService.GetForId((int)id, 2);

			if (retorno != null)
			{
				ClienteViewModel model = new ClienteViewModel() 
				{
					ID = retorno.ID,
					Nome = retorno.Nome,
					Documento = retorno.Documento,
					Email = retorno.Email,
					Telefone = retorno.Telefone,
					Responsavel = retorno.Responsavel,
					Endereco = retorno.Endereco,
					Numero = retorno.Numero,
					Complemento = retorno.Complemento,
					Bairro = retorno.Bairro,
					Cidade = retorno.Cidade,
					Estado = retorno.Estado,
					Cep = retorno.Cep,
				};

				Cliente = model;
			}
			else
			{
				return NotFound();
			}

			return Page();
		}

		[HttpPost]
		public IActionResult OnPost()
		{
			//var dados = Cliente;

			//if (ModelState.IsValid)
			//{
			//	var retorno = _cliente.AtualizarCliente(dados);
			//}

			return Page();
		}
	}
}
