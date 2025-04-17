using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMOC360.Web.Models.Services;
using PMOC360.Web.Models.ViewModels;

namespace PMOC360.Web.Pages.Equipamento
{
    public class IndexModel : PageModel
    {
		private readonly IEquipamentoService _equipamento;
		private readonly IClienteService _cliente;

		public IndexModel(IEquipamentoService equipamento, IClienteService cliente)
		{
			_equipamento = equipamento;
			_cliente = cliente;
		}

		[BindProperty]
		public IEnumerable<EquipamentoViewModel> Equipamentos { get; private set; }

		public string Cliente { get; set; }

		public int CodCliente { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			try
			{
				var retorno = _equipamento.GetAllId((int)id, 2);
				var cliente = _cliente.GetForId((int)id, 2);

				Equipamentos = retorno;
				Cliente = cliente.Nome;
				CodCliente = (int)id;
			}
			catch
			{
				return NotFound();
			}

			return Page();
		}
	}
}
