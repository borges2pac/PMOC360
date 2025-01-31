using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMOC360.API;
using PMOC360.Web.ViewModels;

namespace PMOC360.Web.Pages.Cliente
{
    public class IndexModel : PageModel
    {
		private readonly ClientesController _clientesController;

		public IndexModel(ClientesController clientesController)
		{
			_clientesController = clientesController;
		}

		[BindProperty]
		public IEnumerable<ClienteViewModel> Clientes { get; private set; }

		public string AlertMessage { get; private set; }

		public void OnGet()
		{
			List<ClienteViewModel> clientes = new List<ClienteViewModel>();

			var list = _clientesController.ObterClientes();

			foreach (var item in list) 
			{
				var cliente = new ClienteViewModel
				{
					ID = item.ID,
					Nome = item.Nome,
					Documento = item.Documento,
					Email = item.Email,
					Telefone = item.Telefone,
					Responsavel = item.Responsavel,
					Endereco = item.Endereco,
					Numero = item.Numero,
					Complemento = item.Complemento,
					Bairro = item.Bairro,
					Cidade = item.Cidade,
					Estado = item.Estado,
					Cep = item.Cep,
					Ativo = item.Ativo,
					EmpresaId = item.EmpresaId,
					UserCad = item.UserCad,
					UserAlt = item.UserAlt,
					DataCad = item.DataCad == null ? new DateTime() : Convert.ToDateTime(item.DataCad),
					DataAlt = item.DataAlt == null ? new DateTime() : Convert.ToDateTime(item.DataAlt)
				};

				clientes.Add(cliente);
			}

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
