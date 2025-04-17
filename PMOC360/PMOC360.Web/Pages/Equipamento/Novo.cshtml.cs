using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Services;
using PMOC360.Web.Models.ViewModels;
using System.Reflection;

namespace PMOC360.Web.Pages.Equipamento
{
    public class NovoModel : PageModel
    {
		private readonly IEquipamentoService _equipamento;
		private readonly IClienteService _cliente;

		public NovoModel(IEquipamentoService equipamento, IClienteService cliente)
		{
			_equipamento = equipamento;
			_cliente = cliente;
		}

		[BindProperty]
		public EquipamentoViewModel Equipamento { get; set; }

		public string Cliente { get; set; }

		public int CodCliente { get; set; }

		public string Mensagem { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			try
			{
				var cliente = _cliente.GetForId((int)id, 2);

				Cliente = cliente.Nome;
				CodCliente = (int)id;
			}
			catch
			{
				return NotFound();
			}

			return Page();
		}

		[HttpPost]
		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				var equipamento = Equipamento;

				//Chamar rotina para Inserir o novo equipamento
				if (equipamento != null)
				{
					EquipamentoModel model = new EquipamentoModel() 
					{
						Cliente_ID = equipamento.ClienteID,
						Equipamento = equipamento.Equipamento,
						Fabricante = equipamento.Fabricante,
						Modelo = equipamento.Modelo,
						Potencia = equipamento.Potencia,
						Serie = equipamento.Serie,
						Tag = equipamento.Tag,
						Tipo_Atividade = equipamento.TipoAtividade,
						Ambiente = equipamento.Ambiente,
						Fixos = equipamento.Fixos,
						Flutuantes = equipamento.Flutuantes,
						Pmoc_Modelo_ID = equipamento.PmocModeloID,
						Cod_Etiqueta = equipamento.barCode,
						Cod_Empresa = 2,
						User_Cad = "Administrador",
					};

					var retornoExecucao = _equipamento.Incluir(model);

					Mensagem = retornoExecucao;
				}
				else
				{

				}			
				
				//tratar retorno
				//return RedirectToPage("/Cliente/Index");
			}

			return Page();
		}
	}
}
