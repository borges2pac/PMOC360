using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMOC360.Web.Models.Services.Interfaces;
using PMOC360.Web.Models.ViewModels;

namespace PMOC360.Web.Pages.Pmoc.Operacao
{
    public class InserirModel : PageModel
    {
		private readonly IPmocOperacaoService _service;

		public InserirModel(IPmocOperacaoService service)
		{
			_service = service;
		}

		[BindProperty]
		public PmocOperacaoCadViewModel OperacaoCad { get; private set; }

		[BindProperty]
		public PmocOperacaoViewModel Operacao { get; private set; }

		public List<ItemViewModel> Itens { get; set; } = new();

		public string BarCode { get; private set; }

		public DateTime DataVisita { get; private set; } = DateTime.Now.Date;

		public int ClienteId { get; private set; }

		public int EquipamentoId { get; private set; }

		[BindProperty]
		public int ModeloId { get; private set; }

		public string AlertMessage { get; private set; }

		public async Task<IActionResult> OnGetAsync(string barCode)
		{
			var teste = barCode;

			var operacao = _service.GetDadosOperacao(teste);

			if (operacao != null)
			{
				Operacao = operacao;
				BarCode = barCode;
			}

			return Page();
		}

		[HttpPost]
		public IActionResult OnPostSave()
		{
			var teste1 = EquipamentoId;
			var teste2 = ModeloId;
			var teste3 = ClienteId;
			var teste4 = DataVisita;

			//var selecionados = Operacao.Itens.Where(i => i.Selecionado).ToList();

			var operacaoCad = OperacaoCad;

			//var teste5 = model;


			return Page();
		}
	}
}
