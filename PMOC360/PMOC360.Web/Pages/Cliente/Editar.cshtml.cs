using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMOC360.Web.Controllers;
using PMOC360.Web.ViewModels;

namespace PMOC360.Web.Pages.Cliente
{
    public class EditarModel : PageModel
    {
		private readonly ClientesController _clientesController;

		public EditarModel(ClientesController clientesController)
		{
			_clientesController = clientesController;
		}

		[BindProperty]
		public ClienteViewModel Cliente { get; set; }

		public string Mensagem { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			//var retorno = _cliente.GetListaClietes((int)id);

			//if (retorno.Count == 1)
			//{
			//	ClienteViewModel model = new ClienteViewModel();

			//	foreach (var item in retorno)
			//	{
			//		model.ID = item.ID;
			//		model.Nome = item.Nome;
			//		model.Documento = item.Documento;
			//		model.Email = item.Email;
			//		model.Telefone = item.Telefone;
			//		model.Responsavel = item.Responsavel;
			//		model.Endereco = item.Endereco;
			//		model.Numero = item.Numero;
			//		model.Complemento = item.Complemento;
			//		model.Bairro = item.Bairro;
			//		model.Cidade = item.Cidade;
			//		model.Estado = item.Estado;
			//		model.Cep = item.Cep;
			//	}

			//	Cliente = model;
			//}
			//else
			//{
			//	return NotFound();
			//}

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
