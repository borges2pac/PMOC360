using Microsoft.AspNetCore.Mvc;
using PMOC360.Web.Models.Models;

namespace PMOC360.Web.Models.ViewModels
{
	public class PmocOperacaoViewModel
	{
		public ClienteModel Cliente { get; set; }

		public PmocModeloModel Modelo { get; set; }

		public EquipamentoViewModel Equipamento { get; set; }

		public List<ItemViewModel> Itens { get; set; }
	}
}
